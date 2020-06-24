using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using PII_Word_API;
using System.Collections.Generic;

namespace Library
{
    public class Word : Documento
    {
        
        WordDocument doc = new WordDocument("bitacora.docx");

        public Word()
        {
            
        }

        public override void Escribir()
        {
            doc.AddContent(new TextContent("Hola, soy un texto."));
            doc.AddContent(new TableContent(new List<TableContentRow>(){
                new TableContentRow(new List<TableContentCell>() {
                    new TableContentCell("a"),
                    new TableContentCell("b"),
                    new TableContentCell("c")
                }),
                new TableContentRow(new List<TableContentCell>() {
                    new TableContentCell("d"),
                    new TableContentCell("e"),
                    new TableContentCell("f")
                })
            }), DocumentPosition.TOP);
        }
    }
}