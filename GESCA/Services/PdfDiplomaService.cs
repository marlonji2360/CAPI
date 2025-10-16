using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace GESCA.Services
{
    public class PdfDiplomaService
    {
        // Coordenadas Y (tu plantilla)
        private readonly float Y_Nombre = 305f;
        private readonly float Y_Tema = 180f;
        private readonly float Y_Fechas = 118f;
        private readonly float Y_Dur = 86f;
        private readonly float Y_Puesto = 270f;
        private readonly float Y_Empresa = 225f;

  
        private static void DrawCenteredInBox(
            PdfContentByte cb, BaseFont bf, string text,
            float y, float initialFontSize,
            float xLeft, float xRight,
            BaseColor color = null, float minSize = 8f)
        {
            if (text == null) text = string.Empty;
            float boxWidth = xRight - xLeft;
            float fontSize = initialFontSize;

            // Medir y reducir si no entra
            float textWidth = bf.GetWidthPoint(text, fontSize);
            while (textWidth > boxWidth && fontSize > minSize)
            {
                fontSize -= 0.5f;
                textWidth = bf.GetWidthPoint(text, fontSize);
            }

            float startX = xLeft + (boxWidth - textWidth) / 2f;

            cb.BeginText();
            cb.SetColorFill(color ?? BaseColor.BLACK);
            cb.SetFontAndSize(bf, fontSize);
            // ya calculamos X exacto -> ALIGN_LEFT
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, text, startX, y, 0);
            cb.EndText();
        }

        public void GenerarDiplomaDesdePlantilla(
            string plantillaPdfPath,
            string salidaPdfPath,
            string nombreCompleto,
            string puesto,
            string tema,
            string empresa,
            string capacitador,
            DateTime? fechaInicial,
            DateTime? fechaFinal,
            int? duracionHrs)
        {
            if (!File.Exists(plantillaPdfPath))
                throw new FileNotFoundException("No se encontró la plantilla PDF", plantillaPdfPath);

            using (var reader = new PdfReader(plantillaPdfPath))
            using (var fs = new FileStream(salidaPdfPath, FileMode.Create, FileAccess.Write))
            using (var stamper = new PdfStamper(reader, fs))
            {
                var cb = stamper.GetOverContent(1);

                // Página y márgenes (ajusta si tu plantilla requiere otros)
                var page = reader.GetPageSizeWithRotation(1);
                float xLeft = 60f;                  // margen izquierdo útil
                float xRight = page.Width - 60f;     // margen derecho útil

                // Color corporativo
                var teal = new BaseColor(18, 116, 141);

                // === Fuentes (Unicode + embebidas) ===
                var fontsDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);

                // Leelawadee (no UI)
                string leelaBoldPath = Path.Combine(fontsDir, "leelawdb.ttf");  // Bold
                string leelaRegPath = Path.Combine(fontsDir, "leelawad.ttf");  // Regular

                // Calibri
                string calibriRegPath = Path.Combine(fontsDir, "calibri.ttf");   // Regular
                string calibriBoldPath = Path.Combine(fontsDir, "calibrib.ttf");  // Bold

                // Berlin Sans FB Demi (varía por instalación)
                string berlinDemiPath = FindFontFile("BRLNSDB.TTF", "BRLNSDB.ttf", "BRLNSD.TTF", "BRLNSD.ttf");

                // Cargar BaseFont
                BaseFont bfLeelaBold = BaseFont.CreateFont(leelaBoldPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                BaseFont bfLeelaReg = BaseFont.CreateFont(leelaRegPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                BaseFont bfCalibriReg = BaseFont.CreateFont(calibriRegPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                BaseFont bfCalibriBold = BaseFont.CreateFont(calibriBoldPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                BaseFont bfBerlinDemi = berlinDemiPath != null
                                            ? BaseFont.CreateFont(berlinDemiPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
                                            : bfCalibriBold; // fallback

                // Formateos
                string fechas = FormatearRangoFechas(fechaInicial, fechaFinal);
                string dur = duracionHrs.HasValue ? $"{duracionHrs} horas" : "";

                // === Escritura centrada (misma Y; centrado en franja xLeft..xRight) ===
                DrawCenteredInBox(cb, bfLeelaBold, nombreCompleto, Y_Nombre, 33, xLeft, xRight);
                DrawCenteredInBox(cb, bfLeelaReg, puesto.Replace("*",""), Y_Puesto, 22, xLeft, xRight);
                DrawCenteredInBox(cb, bfCalibriBold, $"De la empresa {empresa}, por su participación en la capacitación:",
                                                           Y_Empresa, 28, xLeft, xRight);
                DrawCenteredInBox(cb, bfBerlinDemi, tema, Y_Tema, 28, xLeft, xRight, teal);
                DrawCenteredInBox(cb, bfLeelaReg, $"Impartida el {fechas}", Y_Fechas, 20, xLeft, xRight);
                DrawCenteredInBox(cb, bfLeelaReg, $"Por {capacitador}, con una duración de {dur}",
                                                           Y_Dur, 20, xLeft, xRight);

                stamper.FormFlattening = true; // “aplana” el contenido
            }
        }

        private string FormatearRangoFechas(DateTime? fi, DateTime? ff)
        {
            var fmt = "dd 'de' MMMM 'de' yyyy";
            if (fi.HasValue && ff.HasValue)
            {
                if (fi.Value.Date == ff.Value.Date) return fi.Value.ToString(fmt, new CultureInfo("es-ES"));
                return $"{fi.Value.ToString(fmt, new CultureInfo("es-ES"))} al {ff.Value.ToString(fmt, new CultureInfo("es-ES"))}";
            }
            if (fi.HasValue) return fi.Value.ToString(fmt, new CultureInfo("es-ES"));
            if (ff.HasValue) return ff.Value.ToString(fmt, new CultureInfo("es-ES"));
            return "";
        }

        private static string FindFontFile(params string[] candidateFiles)
        {
            // 1) C:\Windows\Fonts
            var fontsDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            foreach (var file in candidateFiles)
            {
                var path = Path.Combine(fontsDir, file);
                if (File.Exists(path)) return path;
            }

            // 2) Carpeta local ./Fonts
            var localFonts = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fonts");
            if (Directory.Exists(localFonts))
            {
                foreach (var file in candidateFiles)
                {
                    var path = Path.Combine(localFonts, file);
                    if (File.Exists(path)) return path;
                }
            }

            // 3) Búsqueda simple por nombre exacto
            var allFonts = Directory.Exists(fontsDir)
                ? Directory.GetFiles(fontsDir, "*.ttf", SearchOption.TopDirectoryOnly)
                : Array.Empty<string>();

            var hit = allFonts.FirstOrDefault(p =>
                candidateFiles.Any(c => Path.GetFileName(p).Equals(c, StringComparison.OrdinalIgnoreCase)));

            return hit; // puede ser null
        }
    }
}
