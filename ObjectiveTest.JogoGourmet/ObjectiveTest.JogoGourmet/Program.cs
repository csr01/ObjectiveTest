using ObjectiveTest.JogoGourmet.Models;

var prato = new Prato();

var listaComidas = prato.GerarPratos();

string sair = "N";

Console.WriteLine("Pense em uma comida e eu tentarei adivinhar!");

do
{
    var escolha = "N";

    var totalLoop = 0;

    var tiposPratos = listaComidas.GroupBy(l => l.Tipo).Select(x => x.Key).ToList();

    while (totalLoop < tiposPratos.Count && escolha == "N")
    {
        Console.WriteLine($"A comida que você está pensando é uma {tiposPratos[totalLoop]} ? (S/N)");
        escolha = Console.ReadLine();
        totalLoop++;
    }

    if (escolha == "S")
    {
        var a = listaComidas.Where(x => x.Tipo == tiposPratos[totalLoop - 1]).ToList();
        var pratoAleatorio = GetRandomElement(a);

        Console.WriteLine($"o prato que você está pensando é {pratoAleatorio.Nome} ? (S/N)");
        escolha = Console.ReadLine();

        if (escolha == "S")
        {
            sair = MensagemAcerto();
        }
        else
        {
            var retentativas = listaComidas.Where(x => x.Tipo == pratoAleatorio.Tipo).ToList();
            retentativas.Remove(pratoAleatorio);

            var tentativasRestantes = 0;

            while (tentativasRestantes < retentativas.Count && escolha == "N")
            {
                Console.WriteLine($"O prato que você está pesando é {retentativas.ElementAt(tentativasRestantes).Nome}?");
                escolha = Console.ReadLine();
                tentativasRestantes++;
            }

            if (escolha == "S")
            {
                sair = MensagemAcerto();
            }
            else
            {
                listaComidas.Add(NovoPrato());
            }

        }
    }
    else
    {
        Console.WriteLine($"O prato que você está pensando é {GetRandomElement(listaComidas).Nome} ?");
        escolha = Console.ReadLine();
        if (escolha == "S")
        {
            sair = MensagemAcerto();
        }
        else
        {
            listaComidas.Add(NovoPrato());
        }
    }

    if (sair != "S")
    {
        Console.WriteLine("Deseja sair? (S/N)");
        sair = Console.ReadLine();
    }
}
while (sair == "N");

Prato GetRandomElement(IList<Prato> pratos)
{
    var random = new Random().Next(pratos.Count - 1);

    return pratos.ElementAt(random);
}

string MensagemAcerto()
{
    Console.WriteLine("Eu adivinhei seu prato");
    Console.WriteLine("Deseja Sair? (S/N)");
    var opção = Console.ReadLine();

    return opção;
}

Prato NovoPrato()
{
    var novoPrato = new Prato();
    Console.WriteLine("Qual é o nome do prato que você está pensando? ");
    novoPrato.Nome = Console.ReadLine();

    Console.WriteLine($"{novoPrato.Nome} é um tipo de?");
    novoPrato.Tipo = Console.ReadLine();

    return novoPrato;
}