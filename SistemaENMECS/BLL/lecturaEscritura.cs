using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SistemaENMECS.BLL
{
    class lecturaEscritura
    {
        public string asignarTextos(string valor, string nombreArchivo)
        {
            //Represents a line read from file
            String line;
            String cadenaLeida = null; ;

            //Entero para guardar el indice del caracter :, asi se puede localizar la 
            //cadena de interes dentro de cada linea leida

            int found = 0;
            long position;

            try
            {
                FileStream theFile = File.Open(@nombreArchivo, FileMode.Open, FileAccess.Read);
                StreamReader rdr = new StreamReader(theFile);

                //Search through the stream until we reach the end
                while (!rdr.EndOfStream)
                {
                    line = rdr.ReadLine();
                    position = theFile.Position;

                    if (line.Contains(valor))
                    {
                        found = line.IndexOf(":");
                        cadenaLeida = line.Substring(found + 1).Trim();
                    }
                }
                rdr.Close();
                theFile.Close();
            }
            catch
            {

            }
            return cadenaLeida;
        }

        public void borrarArchivo(string nombreArchivo)
        {
            //File.Delete(@"configdata.txt", FileMode.Open, FileAccess.ReadWrite);
            File.Delete(@nombreArchivo);
        }


        public void escribir(string cadenaAEscribir, string valor, StreamWriter writer)
        {

            try
            {
                writer.WriteLine(valor + " {0}", cadenaAEscribir);
            }
            catch
            {

            }
        }

    }
}
