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
        
        WordDocument doc = new WordDocument("bitacora.docx");

        public Word()
        {
            
        }

        public override void EscribirDocumento(List<Mensaje> datosEspeciales1)
        {
            
            doc.AddContent(new TextContent("........................"));
            doc.AddContent(new TextContent(".:Reflexión Metacognitiva:."));
            doc.AddContent(new TextContent("_______________________"));
            doc.AddContent(new TextContent("  .:Que aprendi hoy:."));
            doc.AddContent(new TextContent("                        "));
            doc.AddContent(new TextContent("_______________________"));
            doc.AddContent(new TextContent("  .:Como lo aprendi:."));
            doc.AddContent(new TextContent("                        "));
            doc.AddContent(new TextContent("_______________________"));
            doc.AddContent(new TextContent("  .:Para que me sirve:."));
            doc.AddContent(new TextContent("                        "));
            doc.AddContent(new TextContent("_______________________"));

            
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
            }), DocumentPosition.TOP);

            
            doc.AddContent(new TextContent("........................"));
            doc.AddContent(new TextContent(".:Objetivos Generales:."));
            foreach (var item in datosEspeciales1)
            {
            //    doc.AddContent(new TextContent(" * "+item.Texto.Txt);    
            }
            

            doc.AddContent(new TextContent("Planificación Semanal (#) FECHA \n"));
            
            
        }
    }
}