using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Método para login
    public async Task<bool> LoginAsync(string email, string senha)
    {
        var loginData = new
        {
            Email = email, // Mapeando o nome da chave conforme a sua API
            Senha = senha
        };

        // Converte o objeto para JSON
        var content = new StringContent(
            JsonSerializer.Serialize(loginData),
            Encoding.UTF8,
            "application/json"
        );

        // Define os cabeçalhos corretamente
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        // Requisição POST para a URL correta
        var response = await _httpClient.PostAsync("http://localhost/api/login::criador", content);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            // Aqui você pode processar a resposta para verificar se há token ou algo relevante
            return true; // Sucesso no login
        }
        else
        {
            // Aqui você pode tratar o erro
            return false; // Falhou no login
        }
    }

    //Método para cadastro
    public async Task<bool> RegisterUserAsync(
    string nome,
    string email,
    string senha,
    string pergunta,
    string resposta)
    {
        // Monta os dados conforme o cURL fornecido
        var registerData = new
        {
            Nome = nome,
            Email = email,
            Senha = senha,
            Pergunta = pergunta,
            Resposta = resposta
        };

        // Serializa os dados para JSON
        var content = new StringContent(
            JsonSerializer.Serialize(registerData),
            Encoding.UTF8,
            "application/json"
        );

        // Define os cabeçalhos corretamente
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

        // Faz a requisição para o endpoint correto
        var response = await _httpClient.PostAsync("http://localhost/api/criador", content);

        if (response.IsSuccessStatusCode)
        {
            // Cadastro bem-sucedido
            return true;
        }
        else
        {
            // Log ou tratamento de erro
            var errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Erro ao cadastrar: {response.StatusCode}, {errorMessage}");
            return false;
        }
    }

}