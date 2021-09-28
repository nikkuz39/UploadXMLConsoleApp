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

                    XmlElement xmlRoot = xmlDocument.DocumentElement;

                    Client client = new Client();

                    foreach (XmlNode xnode in xmlRoot)
                    {
                        XmlNode attr0 = xnode.Attributes.GetNamedItem("CARDCODE");
                        client.CardCode = Convert.ToDouble(attr0.InnerText);

                        XmlNode attr1 = xnode.Attributes.GetNamedItem("STARTDATE");
                        client.StartDate = attr1.Value;

                        XmlNode attr2 = xnode.Attributes.GetNamedItem("FINISHDATE");
                        client.FinishDate = attr2.Value;

                        XmlNode attr3 = xnode.Attributes.GetNamedItem("LASTNAME");
                        client.Lastname = attr3.Value;

                        XmlNode attr4 = xnode.Attributes.GetNamedItem("FIRSTNAME");
                        client.Firstname = attr4.Value;

                        XmlNode attr5 = xnode.Attributes.GetNamedItem("SURNAME");
                        client.Surname = attr5.Value;

                        XmlNode attr6 = xnode.Attributes.GetNamedItem("GENDER");
                        client.Gender = attr6.Value;

                        XmlNode attr7 = xnode.Attributes.GetNamedItem("BIRTHDAY");
                        client.Birthday = attr7.Value;

                        XmlNode attr8 = xnode.Attributes.GetNamedItem("PHONEHOME");
                        client.PhoneHome = attr8.Value;

                        XmlNode attr9 = xnode.Attributes.GetNamedItem("PHONEMOBIL");
                        client.PhoneMobil = attr9.Value;

                        XmlNode attr10 = xnode.Attributes.GetNamedItem("EMAIL");
                        client.Email = attr10.Value;

                        XmlNode attr11 = xnode.Attributes.GetNamedItem("CITY");
                        client.City = attr11.Value;

                        XmlNode attr12 = xnode.Attributes.GetNamedItem("STREET");
                        client.Street = attr12.Value;

                        XmlNode attr13 = xnode.Attributes.GetNamedItem("HOUSE");
                        client.House = attr13.Value;

                        XmlNode attr14 = xnode.Attributes.GetNamedItem("APARTMENT");
                        client.Apartment = attr14.Value;
                    }

                    using (ApplicationContext db = new ApplicationContext())
                    {
                        db.Clients.Add(client);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
