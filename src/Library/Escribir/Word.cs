using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using PII_Word_API;

namespace Library
{
    public class Word : Documento
    {
        private const string InicioSeccion = "........................";
        private const string FinSeccion    = "________________________";
        WordDocument doc = new WordDocument("bitacora.docx");

        public Word()
        {

        }

        public override void EscribirDocumento(List<Mensaje> datosEspeciales)
        {
            escribirMetacognitiva("");
            escribirQueAprendiHoy("");
            escribirComoLoAprendi("");
            escribirParaQueMeSirve("");
            escribirPlanificaionDiaria();
            doc.AddContent(new TextContent("Planificación Semanal (#) FECHA \n"));
        }

        public void escribirMetacognitiva(string texto){
            doc.AddContent(new TextContent(InicioSeccion));
            doc.AddContent(new TextContent("   .:Reflexión Metacognitiva:.   "));
            doc.AddContent(new TextContent(texto));
            doc.AddContent(new TextContent(FinSeccion));
        }

        public void escribirQueAprendiHoy(string texto){
            doc.AddContent(new TextContent(InicioSeccion));
            doc.AddContent(new TextContent("   .:Que aprendi hoy:.   "));
            doc.AddContent(new TextContent(texto));
            doc.AddContent(new TextContent(FinSeccion));
        }

        public void escribirComoLoAprendi(string texto){
            doc.AddContent(new TextContent(InicioSeccion));
            doc.AddContent(new TextContent("   .:Como lo aprendi:.   "));
            doc.AddContent(new TextContent(texto));
            doc.AddContent(new TextContent(FinSeccion));
        }

        public void escribirParaQueMeSirve(string texto){
            doc.AddContent(new TextContent(InicioSeccion));
            doc.AddContent(new TextContent("   .:Para que me sirve:.   "));
            doc.AddContent(new TextContent(texto));
            doc.AddContent(new TextContent(FinSeccion));
        }


        public void escribirPlanificaionDiaria(){
            doc.AddContent(new TextContent("\n \n \n"));
            doc.AddContent(new TextContent("........................"));
            doc.AddContent(new TextContent(".:Planificación Diaria:."));
            doc.AddContent(new TableContent(new List<TableContentRow>(){
                new TableContentRow(new List<TableContentCell>() {
                    new TableContentCell("Tarea"),
                    new TableContentCell("Actividad diaria?(Si/no)"),
                    new TableContentCell("Fecha/Fecha limite/ No aplica")
                }),
                new TableContentRow(new List<TableContentCell>() {
                    new TableContentCell(" "),
                    new TableContentCell(" "),
                    new TableContentCell(" ")
                })
            }), DocumentPosition.BOTTOM);
        }

        public void escribirObjetivosGenerales(List<List<string>> datosEspeciales){
            doc.AddContent(new TextContent("........................"));
            doc.AddContent(new TextContent(".:Objetivos Generales:."));

            List<TableContentRow> tableRows = new List<TableContentRow>();
            foreach (var row in datosEspeciales)
            {
                List<TableContentCell> cells = new List<TableContentCell>();
                foreach (var cell in row){
                    cells.Add(new TableContentCell(cell));
                }
                tableRows.Add(new TableContentRow(cells));
            }
            doc.AddContent(new TableContent(tableRows));
        }
    }
}