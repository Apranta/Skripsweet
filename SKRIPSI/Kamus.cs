using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKRIPSI
{
    class Kamus
    {
        Hashtable data = new Hashtable();
        public Kamus()
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:/dictionary.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        String[] isi = line.Split(';');
                        data.Add(isi[0], isi[1]);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("File Tidak Dapat Dibaca", "Error!!!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public Hashtable getAll()
        {
            return data;
        }

        public String getRow(String key)
        {
            return (String)data[key];
        }
    }
}
