﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tico.Animales.Business.EntAnimales;
using Tico.Animales.DatAnimales;

namespace Tico.Animales.BusAnimales
{
    public class BusAnimal
    {
        public BusAnimal() { }

        public List<EntAnimal> Obtener()
        {
            //DataTable dt = new DataTable();
            //DatAnimal da = new DatAnimal();
            //dt = da.Obtener();
            DataTable dt = new DatAnimal().Obtener();
            List<EntAnimal> list = new List<EntAnimal>();

            foreach (DataRow dr in dt.Rows)
            {
                EntAnimal ani = new EntAnimal();

                ani.Id = dr["Anim_Id"] is DBNull ? 0 : Convert.ToInt32(dr["Anim_Id"]);
                ani.Nombre = dr["Anim_Nomb"].ToString();
                ani.Tipo_Id = Convert.ToInt32(dr["Anim_Tipo_Id"]);
                ani.Tipo.Nombre = dr["Tipo_Nomb"].ToString();
                ani.Color_Id = Convert.ToInt32(dr["Anim_Colo_Id"]);
                ani.Color.Nombre = dr["Colo_Nomb"].ToString();
                ani.Fecha_Alta = dr["Anim_Fech_Alta"] is DBNull ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(dr["Anim_Fech_Alta"]);
                ani.Genero_Id = Convert.ToInt32(dr["Anim_Gene_Id"]);
                ani.Genero.Nombre = dr["Gene_Nomb"].ToString();
                ani.Existencia = Convert.ToInt32(dr["Anim_Exis"]);
                ani.Edad = Convert.ToInt32(dr["Anim_Edad"]);
                ani.Peso = Convert.ToDecimal(dr["Anim_Peso"]);
                ani.Estatus = Convert.ToBoolean(dr["Anim_Esta"]);
                ani.FotoMini = dr["Anim_Foto_Mini"].ToString();
                ani.FotoPortada = dr["Anim_Foto_Port"].ToString();
                ani.Video = dr["Anim_Video"].ToString();

                list.Add(ani);
            }

            return list;
        }

        public EntAnimal Obtener(int id)
        {
            DataTable dt = new DatAnimal().Obtener(id);

            EntAnimal ani = new EntAnimal();
            if (dt.Rows.Count > 0)
            {
                ani.Id = dt.Rows[0]["Anim_Id"] is DBNull ? 0 : Convert.ToInt32(dt.Rows[0]["Anim_Id"]);
                ani.Nombre = dt.Rows[0]["Anim_Nomb"].ToString();
                ani.Tipo_Id = Convert.ToInt32(dt.Rows[0]["Anim_Tipo_Id"]);
                ani.Tipo.Nombre = dt.Rows[0]["Tipo_Nomb"].ToString();
                ani.Color_Id = Convert.ToInt32(dt.Rows[0]["Anim_Colo_Id"]);
                ani.Color.Nombre = dt.Rows[0]["Colo_Nomb"].ToString();
                ani.Fecha_Alta = dt.Rows[0]["Anim_Fech_Alta"] is DBNull ? Convert.ToDateTime("01/01/1900") : Convert.ToDateTime(dt.Rows[0]["Anim_Fech_Alta"]);
                ani.Genero_Id = Convert.ToInt32(dt.Rows[0]["Anim_Gene_Id"]);
                ani.Genero.Nombre = dt.Rows[0]["Gene_Nomb"].ToString();
                ani.Existencia = Convert.ToInt32(dt.Rows[0]["Anim_Exis"]);
                ani.Edad = Convert.ToInt32(dt.Rows[0]["Anim_Edad"]);
                ani.Peso = Convert.ToDecimal(dt.Rows[0]["Anim_Peso"]);
                ani.Estatus = Convert.ToBoolean(dt.Rows[0]["Anim_Esta"]);
                ani.FotoMini = dt.Rows[0]["Anim_Foto_Mini"].ToString();
                ani.FotoPortada = dt.Rows[0]["Anim_Foto_Port"].ToString();
                ani.Video = dt.Rows[0]["Anim_Video"].ToString();

                return ani;
            }
            else
            {
                throw new ApplicationException("No se encontró el animal solicitado");
            }

        }

        public void Insertar(EntAnimal ent)
        {
            int filas = new DatAnimal().Insertar(ent.Nombre, ent.Tipo_Id, ent.Color_Id, ent.Genero_Id, ent.Existencia, ent.Edad, ent.Peso, ent.Estatus, ent.FotoPortada, ent.FotoMini, ent.Video);
            if (filas != 1)
                throw new ApplicationException("Error al insertar animal");
        }

        public void Eliminar(int id)
        {
            int filas = new DatAnimal().Eliminar(id);
            if (filas != 1)
                throw new ApplicationException("Error al insertar animal");
        }
    }
}
