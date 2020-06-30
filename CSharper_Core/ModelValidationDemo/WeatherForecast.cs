using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationDemo
{
    public class WeatherForecast
    {
        [Required]
        public DateTime Date { get; set; }

        [Range(10, 20)]
        [Validations.CustomValidation(ErrorMessage = "SB")]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Range(1, 3)]
        public string Summary { get; set; }
    }
}
