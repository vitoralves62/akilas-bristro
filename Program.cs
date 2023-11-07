string welcomeMessage = @"𝓐𝓴𝓲𝓵𝓪❜𝓼 𝓑𝓲𝓼𝓽𝓻𝓸";

Dictionary<string, List<int>> dishList = new Dictionary<string, List<int>>();
dishList.Add("File a Parmegiana", new List<int> {10, 8, 9, 6});
dishList.Add("Strogonoff de frango", new List<int> {3,4,10});

void ShowLogo()
{
    Console.WriteLine(welcomeMessage);
}

void ShowMenuOptions()
{
    ShowLogo();
    Console.WriteLine("\nMenu:\n");
    Console.WriteLine("1- Registrar um novo prato");
    Console.WriteLine("2- Mostrar todos os pratos");
    Console.WriteLine("3- Avaliar um prato");
    Console.WriteLine("4- Consultar a avaliação de um prato");
    Console.WriteLine("0- Sair");
    Console.Write("\nDigite a opção de sua escolha: ");

    string selectedOption = Console.ReadLine()!;

    int selectedOptionNumber = int.Parse(selectedOption);

    switch (selectedOptionNumber)
    {
        case 1: PostDish();
            break;
        case 2: ShowDishs();
            break;
        case 3: RateDishs();
            break;
        case 4: ShowDishRate();
            break;
        case 0: Console.WriteLine("Foi um prazer ter você por aqui, volte sempre!");
            break;
        default: Console.WriteLine("Opção inválida!");
            break;
    }
}

void showOptionTitle(string tittle)
{
    int letterAccount = tittle.Length;
    string asterisks = string.Empty.PadLeft(letterAccount, '*');
    Console.WriteLine(asterisks);
    Console.WriteLine(tittle);
    Console.WriteLine(asterisks + "\n");
}

void PostDish(){
    Console.Clear();
    ShowLogo();
    showOptionTitle("Registrar um novo prato");
    Console.WriteLine("Digite o nome do seu novo prato: ");
    string dishName = Console.ReadLine()!;
    dishList.Add(dishName, new List<int>());
    Console.WriteLine($"O prato {dishName} foi registrado com sucesso!");
    Thread.Sleep(3000);
    Console.Clear();
    ShowMenuOptions();
}

void ShowDishs()
{
    Console.Clear();
    showOptionTitle("Exibindo todos os pratos");
    foreach (string dish in dishList.Keys)
    {
        Console.WriteLine($"{dish}");
    }
    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ShowMenuOptions();
}

void RateDishs()
{
    Console.Clear();
    showOptionTitle("Avaliar prato");
    Console.Write("Escolha o prato que deseja avaliar:");
    string dishNameforRate = Console.ReadLine()!;
    if (dishList.ContainsKey(dishNameforRate))
    {
        Console.Write($"O prato {dishNameforRate} merece a nota: ");
        int note = int.Parse(Console.ReadLine()!);
        dishList[dishNameforRate].Add(note);
        Console.WriteLine($"\nA nota {note} para {dishNameforRate} foi registrada com sucesso!");
        Thread.Sleep(3000);
        Console.Clear();
        ShowMenuOptions();
    } else
    {
        Console.WriteLine($"\nO prato {dishNameforRate} não faz parte do cardápio.");
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
}

void ShowDishRate()
{
    Console.Clear();
    showOptionTitle("Consultar avaliação do prato");
    Console.Write("Escolha o prato que deseja ver a avaliação:");
    string dishNameRated = Console.ReadLine()!;
    if (dishList.ContainsKey(dishNameRated))
    {
        List<int> values = dishList[dishNameRated];
        if (values != null && values.Any())
        {
            double media = values.Average();
            string mediaWithTwoCases = media.ToString("0.00");
            Console.WriteLine($"\nO prato {dishNameRated} tem a seguinte média {mediaWithTwoCases}.\n");
            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ShowMenuOptions();
        }else
        {
            Console.WriteLine($"\nO prato {dishNameRated} ainda não possúi avaliações.\n");
            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal.");
            Console.ReadKey();
            Console.Clear();
            ShowMenuOptions();
        }
    } else
    {
        Console.WriteLine($"\nO prato {dishNameRated} não faz parte do cardápio.");
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
}

ShowMenuOptions();
