using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetSortTagHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetSortTagHelper.Data
{
    public static class Initializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            PetContext context = app.ApplicationServices.GetRequiredService<PetContext>();
            context.Database.Migrate();
            if (!context.Cats.Any())
            {
                Disease[] diseases = new Disease[]
                {
                    new Disease{Name="Микоплазмоз"},
                    new Disease{Name="Бешенство"},
                    new Disease{Name="Калицивироз"},
                    new Disease{Name="Вирусный ринотрахеит"},
                    new Disease{Name="Панлейкопения"}
                };
                context.Diseases.AddRange(diseases);
                context.SaveChanges();

                Vaccine vaccine1 = new Vaccine
                {
                    Name = "Nobivak",
                    Code = "A379B01",
                    Producer = "Intervet International B.V.",
                    Country = "Holland",
                    Price = 180,
                    Diseases = new List<Disease> { diseases[2], diseases[3], diseases[4] }
                };

                Vaccine vaccine2 = new Vaccine
                {
                    Name = "Virbac Rabigen Mono",
                    Code = "A379B01",
                    Producer = "Virbac S.A.",
                    Country = "France",
                    Price = 60,
                    Diseases = new List<Disease> { diseases[1] }
                };

                context.Vaccines.AddRange(vaccine1, vaccine2);
                context.SaveChanges();

                Passport[] passports = new Passport[]
                {
                    new Passport{Number="11415282",GrantDate=new DateTime(2019,04,10),PetOwnerstName="Борищак Виталий Дмитриевич",
                        Grafts =new List<Graft>
                        {
                            new Graft{Date=new DateTime(2019,04,10),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2019,05,03),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2019,05,03),Vaccine=vaccine2,Price=230 }
                        }
                    },

                    new Passport{Number="25332543",GrantDate=new DateTime(2016,11,07),PetOwnerstName="Сутулый Петр Николаевич",
                    Grafts = new List<Graft>
                        {
                            new Graft{Date=new DateTime(2016,11,07),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2016,12,01),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2016,08,07),Vaccine=vaccine2,Price=230 },
                            new Graft{Date=new DateTime(2017,11,04),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2017,11,28),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2017,08,01),Vaccine=vaccine2,Price=230 },
                            new Graft{Date=new DateTime(2018,11,01),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2018,11,15),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2018,08,06),Vaccine=vaccine2,Price=230 }
                        }
                    },
                    new Passport{Number="35322542",GrantDate=new DateTime(2019,06,22),PetOwnerstName="Забавный Гиви Иакович",
                           Grafts = new List<Graft>
                        {
                            new Graft{Date=new DateTime(2019,05,10),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2019,06,01),Vaccine=vaccine1,Price=250 },
                            new Graft{Date=new DateTime(2019,06,01),Vaccine=vaccine2,Price=230 },

                        }
                    }
                };
                context.Passports.AddRange(passports);
                context.SaveChanges();

                Cat[] cats = new Cat[]
                {
                    new Cat{Name="Марсик",Breed="Мэйн кун",Passport=passports[0],Birthday=new DateTime(2018,11,25)},
                    new Cat{Name="Вера",Breed="Британская короткошерстая",Passport=passports[1],Birthday=new DateTime(2016,05,07)},
                    new Cat{Name="Голем",Breed="Сфинкс",Passport=passports[2],Birthday=new DateTime(2019,03,08)}
                };
                context.Cats.AddRange(cats);
                context.SaveChanges();
            }
        }
    }
}
