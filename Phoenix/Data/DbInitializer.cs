using Microsoft.EntityFrameworkCore;
using Phoenix.DAL.Context;
using Phoenix.DAL.Entityes;
using Phoenix.Helpers.Extensions;
using System;
using System.Threading.Tasks;

namespace Phoenix.Data
{
    class DbInitializer
    {
        private readonly PhoenixDB _db;

        public DbInitializer(PhoenixDB db)
        {
            _db = db;
        }
        /// <summary>
        /// Механизм миграций, заполнение бд тестовыми даными
        /// </summary>
        public async Task InitializeAsync()
        {
            //await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            //await _db.Database.MigrateAsync().ConfigureAwait(false);

            if (await _db.Massages.AnyAsync())
                return;
            await SeedDataCategory();
            await SeedDataMassage();
            await SeedDataClient();
            await SeedDataMaster();
            await SeedDataVisit();
        }
        private Category[] _categories;
        #region Тестовые даные категории
        public async Task SeedDataCategory()
        {
            _categories = new Category[]
            {
                    new Category()
                    {
                        Name = "Класический"
                    },
                    new Category()
                    {
                        Name = "СПА"
                    },
                    new Category()
                    {
                        Name = "Спортивный"
                    },
                    new Category()
                    {
                        Name = "Баночный"
                    },
            };
            await _db.Categories.AddRangeAsync(_categories);
            await _db.SaveChangesAsync();
        }
        #endregion

        private Massage[] _massages;
        #region Тестовые даные массажи

        public async Task SeedDataMassage()
        {
            var rnd = new Random();
            _massages = new Massage[]
            {
                    new Massage()
                    {
                        Name = "Спина",
                        Description = "This is the description of the first cinema",
                        Duration = 30,
                        Category = rnd.NextItem(_categories)
                    },
                    new Massage()
                    {
                        Name = "лицо",
                        Description = "This isлицо the лицолицо of the лицо л ицол  ицол ицолицо cinema",
                        Duration = 40,
                        Category = rnd.NextItem(_categories)
                    },
                    new Massage()
                    {
                        Name = "Живот",
                        Description = "ЖивотThis is Живот the description Живот of the first cinema Живот",
                        Duration = 30,
                        Category = rnd.NextItem(_categories)
                    },
                    new Massage()
                    {
                        Name = "Швз",
                        Description = " Швз This is the descr Швз Швз iption of the first cinema Швз",
                        Duration = 30,
                        Category = rnd.NextItem(_categories)
                    },
                    new Massage()
                    {
                        Name = "нога",
                        Description = " нога This  is  the нога descrip нога tion of the first cinema нога",
                        Duration = 30,
                        Category = rnd.NextItem(_categories)
                    },
                    new Massage()
                    {
                        Name = "пятка",
                        Description = "пятка This is the d пятка escription of the first cinema пятка пятка пяткампяткапяткапяткапятка   пяткам пяткам пятка",
                        Duration = 30,
                        Category = rnd.NextItem(_categories)
                    },
                    new Massage()
                    {
                        Name = "хвост",
                        Description = " хвост хвост мхвостхвостхвост хвост  хвост хвост хвост хвост хвостThis is the description of the first cinema",
                        Duration = 30,
                        Category = rnd.NextItem(_categories)
                    },
            };
            await _db.Massages.AddRangeAsync(_massages);
            await _db.SaveChangesAsync();
        }
        #endregion

        private Client[] _clients;
        #region Тестовые даные клиенты
        public async Task SeedDataClient()
        {
            _clients = new Client[]
            {
                    new Client()
                    {
                        Name = "qwer",
                        Surname = "qwer",
                        Patronymic = "qwer",
                        Phone = 31231231,
                        Age = 12,
                        Description = "asd dddddddd dddddd ddd dddddd dddddddd  dddddd ddddddd dddddd dddddd ddd ddd dd ddddd asda",
                    },
                    new Client()
                    {
                        Name = "fghj",
                        Surname = "fghj",
                        Patronymic = "fghj",
                        Age = 12,
                        Description = "asd dddddddd dddddd ddd dddddd dddddddd  dddddd ddddddd dddddd dddddd ddd ddd dd ddddd asda",
                        Phone = 312321321
                    },
                    new Client()
                    {
                        Name = "zcasads",
                        Surname = "zcasads",
                        Patronymic = "zcasads",
                        Age = 12,
                        Description = "asd dddddddd dddddd ddd dddddd dddddddd  dddddd ddddddd dddddd dddddd ddd ddd dd ddddd asda",
                        Phone = 23424234
                    },
                    new Client()
                    {
                        Name = "awdadd",
                        Surname = "awdadd",
                        Patronymic = "awdadd",
                        Age = 12,
                        Description = "asd dddddddd dddddd ddd dddddd dddddddd  dddddd ddddddd dddddd dddddd ddd ddd dd ddddd asda",
                        Phone = 2131312453
                    },
                    new Client()
                    {
                        Name = "sdfgbdw",
                        Surname = "sdfgbdw",
                        Patronymic = "sdfgbdw",
                        Age = 12,
                        Description = "asd dddddddd dddddd ddd dddddd dddddddd  dddddd ddddddd dddddd dddddd ddd ddd dd ddddd asda",
                        Phone = 24235234324
                    },
                    new Client()
                    {
                        Name = "dadqewq",
                        Surname = "dadqewq",
                        Patronymic = "dadqewq",
                        Age = 12,
                        Description = "asd dddddddd dddddd ddd dddddd dddddddd  dddddd ddddddd dddddd dddddd ddd ddd dd ddddd asda",
                        Phone = 5654234232
                    },
                    new Client()
                    {
                        Name = "addadadad",
                        Surname = "addadadad",
                        Patronymic = "addadadad",
                        Age = 12,
                        Description = "asd dddddddd dddddd ddd dddddd dddddddd  dddddd ddddddd dddddd dddddd ddd ddd dd ddddd asda",
                        Phone = 565422334232
                    },
            };
            await _db.Clients.AddRangeAsync(_clients);
            await _db.SaveChangesAsync();
        }

        #endregion

        private Master[] _masters;
        #region Тестовые даные мастера
        public async Task SeedDataMaster()
        {
            _masters = new Master[]
            {
                    new Master()
                    {
                        Name = "павпвапав",
                        Surname = "qыаыаыаwer",
                        Patronymic = "qпаввыаыаwer",
                    },
                            };
            await _db.Masters.AddRangeAsync(_masters);
            await _db.SaveChangesAsync();
        }
        #endregion

        private Visit[] _visits;
        #region Тестовые даные посищения
        public async Task SeedDataVisit()
        {
            var rnd = new Random();
            _visits = new Visit[]
            {
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
                    new Visit()
                    {
                        Massage = rnd.NextItem(_massages),
                        Client = rnd.NextItem(_clients),
                        Master = rnd.NextItem(_masters),
                        Price = (decimal) (rnd.NextDouble() * 400 + 700)
                    },
            };
            await _db.Visits.AddRangeAsync(_visits);
            await _db.SaveChangesAsync();
        }
        #endregion
    }
}
