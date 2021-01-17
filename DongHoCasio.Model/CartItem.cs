﻿using DongHoCasio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DongHoCasio.Model
{
    [Serializable]
    public class CartItem
    {
        [StringLength(30)]
        public SanPham SanPham { get; set; }

        public int SoLuong { get; set; }
      
    }
}