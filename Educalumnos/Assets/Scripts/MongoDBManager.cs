using UnityEngine;
using MongoDB.Driver;
using TMPro;
using MongoDB.Bson;


public class MongoDBManager : MonoBehaviour
{
    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<Jugador> jugadoresCollection;
    public TMP_Text textoUI; 

    private void Start()
    {
        string connectionString = "mongodb+srv://mariagmenr:laravel8@cluster0.u0z54ln.mongodb.net/?retryWrites=true&w=majority";
        client = new MongoClient(connectionString);
        database = client.GetDatabase("Educalumnos");
        jugadoresCollection = database.GetCollection<Jugador>("jugadores");
        ConsultarMejoresPuntajes();
    }

    public void RegistrarJugador(string nombre)
    {
        Jugador nuevoJugador = new Jugador { Nombre = nombre, Puntaje = 0 };

        jugadoresCollection.InsertOne(nuevoJugador);

        Debug.Log("Jugador registrado en MongoDB: " + nombre);
    }

    void ConsultarMejoresPuntajes()
    {
        var collection = database.GetCollection<BsonDocument>("jugadores");

        var filtro = Builders<BsonDocument>.Filter.Empty;

        var opcionesOrden = Builders<BsonDocument>.Sort.Descending("Puntaje");

        var resultados = collection.Find(filtro).Sort(opcionesOrden).Limit(5).ToList();

        // Procesa los resultados.
        foreach (var documento in resultados)
        {
            // Extrae el nombre y el puntaje del documento.
            var nombre = documento["Nombre"].AsString; 
            var puntaje = documento["Puntaje"].AsInt32; 

            // Concatena el texto y actualiza la interfaz de usuario.
            textoUI.text += $"{nombre}     {puntaje}\n";
        }
    }

}

public class Jugador
{
    public string Nombre { get; set; }
    public int Puntaje { get; set; }
}
