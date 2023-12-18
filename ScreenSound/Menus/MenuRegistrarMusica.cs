using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Registro de músicas");
        Console.Write("Digite a banda cuja música deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Digite o título do álbum de {nomeDaBanda}: ");
            string tituloAlbum = Console.ReadLine()!;
            Banda banda = bandasRegistradas[nomeDaBanda];
            Album? album = banda.Albuns.FirstOrDefault(a => a.Nome.Equals(tituloAlbum));
            if (album is not null)
            {
                Console.Write("Agora digite o nome da música: ");
                var nomeMusica = Console.ReadLine()!;
                Musica musica = new Musica(banda, nomeMusica);
                album.AdicionarMusica(musica);
                Console.WriteLine($"A música {nomeMusica} foi registrada com sucesso!");
                Thread.Sleep(4000);
                Console.Clear();

            } else
            {
                Console.WriteLine($"\nÁlbum {tituloAlbum} não foi encontrado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
