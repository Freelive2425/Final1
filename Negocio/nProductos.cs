using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
namespace Negocio
{
    public class nProductos
    {
        dProductos productosdd;
        public nProductos()
        {
            productosdd = new dProductos();
        }
        public string Registrarproducto(string codp, string descp, decimal preciop, int existp)
        {
            eProductos objeto = new eProductos()
            {
                Codigo = codp,
                Descripcion = descp,
                Precio = preciop,
                Existencias = existp
            };
            return productosdd.insertar(objeto);
        }
        public string Modificarproducto(string codp,string descp,decimal preciop,int existp)
        {
            eProductos objeto = new eProductos()
            {
                Codigo = codp,
                Descripcion = descp,
                Precio = preciop,
                Existencias = existp
            };
            return productosdd.modificar(objeto);
        }
        public string Eliminarproducto(string codp)
        {
            return productosdd.eliminar(codp);
        }
        public List<eProductos> Listarproductos()
        {
            return productosdd.listartodo();
        }
        public List<eProductos> ListarCriterio(decimal precio,int existencia,int opcion)
        {
            return productosdd.listarxcriterio(precio, existencia, opcion);
        }
    }
}
