using System;

namespace TELEPHONEDIRECTORY
{
    public class Contact
    {
        //declaration de Atributos
        public string name { get; set; }
        public string telephone { get; set; }
        public string phone { get; set; }
        public Contact(string name, string telephone, string phone)
        {
            this.name = name;
            this.telephone = telephone;
            this.phone = phone;
        }
        public Contact (string name){
            this.name = name;
        }

        public static implicit operator List<object>(Contact v)
        {
            throw new NotImplementedException();
        }
    }
}