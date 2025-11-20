public class WeatherResponse {
    public CurrentWeather? current { get; set; }
    public Hourly? hourly { get; set; }
}

public class CurrentWeather {
    public string? time { get; set; }
    public double? temperature_2m { get; set; }
    public double? wind_speed_10m { get; set; }
    public double? relative_humidity_2m { get; set; }
    public double? wind_direction_10m { get; set; }
}

public class Hourly {
    public List<string>? time { get; set; }
    public List<double>? temperature_2m { get; set; }
}
