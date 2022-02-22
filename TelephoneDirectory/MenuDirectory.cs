using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace TELEPHONEDIRECTORY
{

    public class MenuDirectory
    {
        PhoneBook phoneBook = new PhoneBook();
        byte optionMenu, size;
        string name, phone, telephone;


        public void MenuDirectoryTelePhone()
        {
            do
            {
                try
                {
                    Console.Clear();
                    //ingresamos el tamaño del arrgelo
                    GetSizeDirectory();
                    //llamamos el metodo para asignar el tamaño arreglo
                    phoneBook.SizeArray(size);
                    if (size == 0)
                    {
                        Console.WriteLine("No se puede tener un array de 0");
                        Console.ReadLine();
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("{0}", error.Message);
                    Console.ReadLine();
                }

            } while (size < 1);
            do
            {
                try
                {
                    //llamamos el menu;
                    GetMenu();

                    //inicializamos
                    optionMenu = byte.Parse(Console.ReadLine());
                    switch (optionMenu)
                    {
                        //agregar un contacto
                        case (byte)PhoneBook.enumResult.addContact:
                            {
                                Console.Clear();
                                GetContact();
                                if (Validations() == true)
                                {
                                    Console.ReadLine();
                                    break;
                                }
                                phoneBook.AddContact(new Contact(name, telephone, phone));
                                Console.ReadLine();
                                break;
                            }

                        // Mostrar lista Completa de contactos
                        case (byte)PhoneBook.enumResult.listContacts:
                            {
                                Console.Clear();
                                phoneBook.ListContacts();
                                Console.ReadLine();
                                break;
                            }

                        // Buscar un contacto
                        case (byte)PhoneBook.enumResult.searchContact:
                            {
                                Console.Clear();
                                getName();
                                phoneBook.SearchContact(name);
                                Console.ReadLine();
                                break;
                            }

                        //Contacto existente
                        case (byte)PhoneBook.enumResult.existContact:
                            {
                                Console.Clear();
                                getName();
                                Contact contact = new Contact(name);
                                phoneBook.ExistingContact(contact);
                                Console.ReadLine();
                                break;
                            }

                        // Eliminar un contacto
                        case (byte)PhoneBook.enumResult.deleteContact:
                            {
                                Console.Clear();
                                getName();
                                Contact contact = new Contact(name);
                                phoneBook.DeleteContact(contact);
                                Console.ReadLine();
                                break;
                            }

                        //Mirar si el directorio esta lleno
                        case (byte)PhoneBook.enumResult.fullDirectory:
                            {
                                Console.Clear();
                                phoneBook.DirectoryFull();
                                Console.ReadLine();
                                break;
                            }

                        //Muestra espacio libres en el directorio
                        case (byte)PhoneBook.enumResult.freeSpaces:
                            {
                                Console.Clear();
                                phoneBook.FreeSpaces();
                                Console.ReadLine();
                                break;
                            }
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("{0}", error.Message);
                    Console.ReadLine();
                }
            } while (optionMenu < 8);

        }
        private void GetSizeDirectory()
        {
            Console.WriteLine("Plis enter array size");
            size = byte.Parse(Console.ReadLine());
        }
        private void GetContact()
        {
            getName();
            GetTelephone();
            GetPhone();
        }
        private void getName()
        {
            Console.WriteLine("Plis enter the name of the contact");
            name = Console.ReadLine();
        }
        private void GetTelephone()
        {
            Console.WriteLine("Enter the cell phone from {0}", name);
            telephone = Console.ReadLine();
        }
        private void GetPhone()
        {
            Console.WriteLine("Enter the phone from  {0}", name);
            phone = Console.ReadLine();
        }
        private void GetMenu()
        {
            Console.Clear();
            Console.WriteLine("DIRECTORIO TELEFÓNICO \n\n1.- Agregar un nuevo contacto. \n\n2.- Mostrar lista de contactos. \n\n3.- Buscar un contacto. \n\n4.- Existe contacto.  \n\n5.- Borrar contacto. \n\n6.- Agenda llena. \n\n7.- Espacios Disponibles. \n\n8.- Salir");
        }

        private bool Validations()
        {
            List<Contact> contacts = new List<Contact>();
            var contact = new Contact(name, telephone, phone);
            contacts.Add(contact);
            ContactValidator validator = new ContactValidator(contacts);
            ValidationResult results = validator.Validate(contact);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("no hay errores");
            }
            return false;
        }
    }
}
