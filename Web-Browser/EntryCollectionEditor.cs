﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{

    public partial class EntryCollectionEditor : Form 
    {
        public static class EntryCollectionEditorBuilder<T> where T : EntryRecord
        {
            public static EntryCollectionEditor NewWindow(T source)
            {
                return new EntryCollectionEditor();
            }
        }
        private EntryCollectionEditor()
        {
            InitializeComponent();
        }
    }
}
