using System;
using System.Xml;
using System.IO;
using ClientLibrary;

namespace UploadXMLConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string path in args)
            {
                if (File.Exists(path))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(path);

                    // Получаем корневой элемент
                    XmlElement xmlRoot = xmlDocument.DocumentElement;

                    // Выбераем все узлы "Card" из XML документа
                    XmlNodeList xmlNodeList = xmlRoot.SelectNodes("Card");

                    // Обходим все узлы в корневом элементе
                    foreach (XmlNode xnode in xmlNodeList)
                    {
                        // Создаем объект класса "Client"
                        Client client = new Client();

                        // Получаем значение атрибутов, в корневом элементе, и передаем их в свойства объекта класса "Client"
                        XmlNode cardCodeXml = xnode.Attributes.GetNamedItem("CARDCODE");
                        client.CardCode = Convert.ToDouble(cardCodeXml.InnerText);

                        XmlNode startDateXml = xnode.Attributes.GetNamedItem("STARTDATE");
                        client.StartDate = startDateXml.Value;

                        XmlNode finishDateXml = xnode.Attributes.GetNamedItem("FINISHDATE");
                        client.FinishDate = finishDateXml.Value;

                        XmlNode lastnameXml = xnode.Attributes.GetNamedItem("LASTNAME");
                        client.Lastname = lastnameXml.Value;

                        XmlNode firstnameXml = xnode.Attributes.GetNamedItem("FIRSTNAME");
                        client.Firstname = firstnameXml.Value;

                        XmlNode surnameXml = xnode.Attributes.GetNamedItem("SURNAME");
                        client.Surname = surnameXml.Value;

                        XmlNode fullNameXml = xnode.Attributes.GetNamedItem("FULLNAME");
                        client.FullName = fullNameXml.Value;

                        XmlNode genderIdXml = xnode.Attributes.GetNamedItem("GENDERID");
                        client.GenderId = genderIdXml.Value;

                        XmlNode birthdayXml = xnode.Attributes.GetNamedItem("BIRTHDAY");
                        client.Birthday = birthdayXml.Value;

                        XmlNode phoneHomeXml = xnode.Attributes.GetNamedItem("PHONEHOME");
                        client.PhoneHome = phoneHomeXml.Value;

                        XmlNode phoneMobilXml = xnode.Attributes.GetNamedItem("PHONEMOBIL");
                        client.PhoneMobil = phoneMobilXml.Value;

                        XmlNode emailXml = xnode.Attributes.GetNamedItem("EMAIL");
                        client.Email = emailXml.Value;

                        XmlNode cityXml = xnode.Attributes.GetNamedItem("CITY");
                        client.City = cityXml.Value;

                        XmlNode streetXml = xnode.Attributes.GetNamedItem("STREET");
                        client.Street = streetXml.Value;

                        XmlNode houseXml = xnode.Attributes.GetNamedItem("HOUSE");
                        client.House = houseXml.Value;

                        XmlNode apartmentXml = xnode.Attributes.GetNamedItem("APARTMENT");
                        client.Apartment = apartmentXml.Value;

                        XmlNode altAddressXml = xnode.Attributes.GetNamedItem("ALTADDRESS");
                        client.AltAddress = altAddressXml.Value;

                        XmlNode cardTypeXml = xnode.Attributes.GetNamedItem("CARDTYPE");
                        client.CardType = cardTypeXml.Value;

                        XmlNode ownerguidXml = xnode.Attributes.GetNamedItem("OWNERGUID");
                        client.Ownerguid = ownerguidXml.Value;

                        XmlNode cardperXml = xnode.Attributes.GetNamedItem("CARDPER");
                        client.Cardper = cardperXml.Value;

                        XmlNode turnoverXml = xnode.Attributes.GetNamedItem("TURNOVER");
                        client.Turnover = turnoverXml.InnerText;

                        try
                        {
                            // Подключаемся к базе данных
                            using (ApplicationContext db = new ApplicationContext())
                            {
                                // В базу данных передаем объект класса "Client", в котором хранятся данные из XML документа
                                db.Clients.Add(client);
                                // Сохраняем изменения в базе данных
                                db.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);                            
                        }
                    }
                }
            }
        }
    }
}
