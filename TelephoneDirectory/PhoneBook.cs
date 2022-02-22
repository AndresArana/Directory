using System;
namespace TELEPHONEDIRECTORY;
public class PhoneBook
{
    public enum enumResult : byte
    {
        addContact = 1,
        listContacts,
        searchContact,
        existContact,
        deleteContact,
        fullDirectory,
        freeSpaces,
    }
    //declaramos algunas variables
    public byte contactFound;
    public byte i = 0;
    public Contact[] datacontacts = new Contact[10];
    public byte contactAdd = 0;

    //tamaño del arreglo
    public byte SizeArray(byte size)
    {
        try
        {
            //aca definimos el tamaño que queremos que tenga el arreglo
            datacontacts = new Contact[size];
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return size;
    }
    //Agregar un contacto
    public void AddContact(Contact contact)
    {
        try
        {
            //validamos si el directorio esta lleno
            if (FullDirectory()) return;
            //validamos que el contacto no se repita
            if (ExistingContact(contact)) return;
            //asignamos los datos al directorio
            datacontacts[contactAdd] = contact;
            //aumentamos el contador que nos dira cuantos contactos tiene el directorio registrados
            contactAdd += 1;
            //mandamos el mensaje que el contacto ha sido agregado exitosamente
            Console.WriteLine("Contact added successfully");
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
    }

    //listar todos los contactos
    public byte ListContacts()
    {
        try
        {
            //hacemos un ciclo recorriendo todo el directorio
            for (i = 0; i < contactAdd; i++)
            {
                //imprimimos la informacion de los contactos encontrados
                InfoContact();
                contactFound += 1;
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return contactFound;
    }

    //existe un contacto
    public bool ExistingContact(Contact contact)
    {
        try
        {
            for (i = 0; i < contactAdd; i++)
                if (datacontacts[i].name.Equals(contact.name))
                {
                    //imprimimos el mensaje que el contacto ya existe y nos devuelve para ingresar de nuevo
                    Console.WriteLine("contact already exists");
                    return true;
                }
            Console.WriteLine("contact does not exists");
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return false;
    }
    
    //Buscar un contacto
    public bool SearchContact(string contactName)
    {
        try
        {
            //hacemos un ciclo de todo el directorio
            for (i = 0; i < contactAdd; i++)
                //buscamos por cada puesto y comparamos si el nombre ingresado ya esta en el directorio
                if (datacontacts[i].name.Equals(contactName))
                {
                    Console.Clear();
                    //Imprimimos la informacion del contacto encontrado
                    InfoContact();
                    return true;
                }
            //sino existe ningun nombre igual en el directorio se imprime el mensaje que no existe el contacto
            Console.WriteLine("contact does not exist");
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return false;
    }

    //Eliminar un contacto
    public bool DeleteContact(Contact contact)
    {
        try
        {
            //Hacemos un ciclo al directorio
            for (i = 0; i < contactAdd; i++)
            {
                //aca buscamos en cada posicion el nombre del contacto a eliminar
                if (datacontacts[i].name.Equals(contact.name))
                {
                    //si se encontro el contacto procede a eliminarlo
                    Console.Clear();
                    //disminuimos el contador que es el que tiene la informacion de cuantos contactos hay en el directorio
                    contactAdd--;
                    //procedemos a eliminar la informacion en la posicion donde encontramos el nombre
                    datacontacts[i] = null;
                    //se mostrara un mensaje que diga el contacto ha sido eliminado
                    Console.WriteLine("contact deleted successfully");
                    return true;
                }
                //sino se encontro el contacto digitado se procede a mostrar el mensaje que el contacto no existe
                Console.WriteLine("contact does not exist");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return false;
    }

    //Mirar si el directorio esta lleno o no esta lleno
    public bool DirectoryFull()
    {
        try
        {
            //validamos si el directorio esta lleno.
            if (FullDirectory()) return true;
            //sino esta lleno manda un mensaje que dice que no esta lleno.
            Console.WriteLine("the directory is not full");
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return false;
    }

    //Muestra espacio libres en el directorio
    public bool FreeSpaces()
    {
        try
        {
            //Aca validamos los espacios disponibles
            if (contactAdd < datacontacts.Length)
            {
                //hacemos la siguienete operacion para saber cuantos contactos hay en el directorio
                long spacesFree = datacontacts.Length - contactAdd;
                //Mostramos el mensaje de los espacios disponibles
                Console.WriteLine("You can enter " + spacesFree + " contacts to the directory");
                return true;
            }
            //imprimimos que no hay espacios disponibles
            Console.WriteLine("There are no spaces available");
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return false;
    }

    //Aca veremos la info completa del contacto
    private void InfoContact()
    {
        Console.WriteLine("{0}", "Name: " + datacontacts[i].name + " \nPhone: " + datacontacts[i].phone + " \nTelephone: " + datacontacts[i].telephone + "\n");
    }

    //valida solo si el directorio esta lleno
    private bool FullDirectory()
    {
        try
        {
            if (contactAdd == datacontacts.Length)
            {
                //si es igual saldra un mensaje que diga que el directorio esta lleno
                Console.WriteLine("Directory is full");
                return true;
            }
        }
        catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }
        return false;
    }
}

