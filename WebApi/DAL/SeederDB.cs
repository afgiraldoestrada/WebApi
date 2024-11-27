using System.Security.Cryptography.X509Certificates;
using WebApi.DAL.Entities;

namespace WebApi.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;
        public SeederDB(DataBaseContext context) //Esto y lo anterior es pura inyección de dependencia
        {
            _context = context;
        }

        //Creamos un metodo llamado SeederAsync => Es una especio de metodo main() => Este metodo tendrá la responsabilidad de repoblar mis diferentes tablas de las BD
        public async Task SeederAsync()
        {
            //Agregare un metodo propio de EntityFramework que hace las veces del comando update database
            await _context.Database.EnsureCreatedAsync();

            //A partir de aqui vamos a crear metodos que sirven para poblar la BD
            await PopulateCountriesAsync();

            await _context.SaveChangesAsync(); //Esta linea guarda lo datos en la BD
        }

        #region
        private async Task PopulateCountriesAsync()
        {
            if (!_context.Countries.Any()) //Si al menos hay un registro en la tabla
            {
                //Asi creo yo un objeto pais con sus respectivos estados
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }
                });

                //Aqui creo otro nuevo país 
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }                        
                    }
                });
            }
        }
        #endregion
    }
}
