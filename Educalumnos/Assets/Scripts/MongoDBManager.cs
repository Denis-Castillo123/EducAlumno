using UnityEngine;
using MongoDB.Driver;

public class MongoDBManager : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<Jugador> jugadoresCollection;

    private void Start()
    {
        string connectionString = "mongodb+srv://mariagmenr:laravel8@cluster0.u0z54ln.mongodb.net/?retryWrites=true&w=majority";
        client = new MongoClient(connectionString);
        database = client.GetDatabase("Educalumnos");
        jugadoresCollection = database.GetCollection<Jugador>("jugadores");
    }

    public void RegistrarJugador(string nombre)
    {
        Jugador nuevoJugador = new Jugador { Nombre = nombre, Puntaje = 0 };

        jugadoresCollection.InsertOne(nuevoJugador);

        Debug.Log("Jugador registrado en MongoDB: " + nombre);
    }
}

public class Jugador
{
    public string Nombre { get; set; }
    public int Puntaje { get; set; }
}
