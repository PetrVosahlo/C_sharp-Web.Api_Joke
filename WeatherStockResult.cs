namespace Web.Api_Joke {
    public class WeatherStockResult {
        public int weather_code;
        public string description;
        public string pictureAddress;
        public double temperature;
        public double windSpeed;
        public double humidity;
        public int id;
        public string content;
        public string userName;
        public WeatherStockResult(WeatherStockModel weatherStockModel, Joke_Weather joke_Weather) {
            this.weather_code = weatherStockModel.Current.Weather_code;
            this.description = getCzechDescription();
            this.pictureAddress = getPicture();
            this.temperature = weatherStockModel.Current.Temperature;
            this.windSpeed = weatherStockModel.Current.Wind_speed;
            this.humidity = weatherStockModel.Current.humidity;
            this.id = joke_Weather.Id;
            this.content = joke_Weather.Content;
            this.userName = "Petr";
        }
        public WeatherStockResult(int weather_code, double temperature, double wind_speed, Joke_Weather joke_Weather) {
            this.weather_code = weather_code;
            this.description = getCzechDescription();
            this.pictureAddress = getPicture();
            this.temperature = temperature;
            this.windSpeed = wind_speed;
            this.humidity = 70;
            this.id = joke_Weather.Id;
            this.content = joke_Weather.Content;
            this.userName = "Petr";
        }
        private string getPicture() {
            string picture = "";
            switch (weather_code) {
                case 113: picture = "113_Sunny.jpg"; break;
                case 116: picture = "116_PartlyCloudy.jpg"; break;
                case 143: picture = "143_Mist.jpg"; break;
                case 176: picture = "176_PatchyRain.jpg"; break;
                case 185: picture = "185_PatchyFreezingDrizzle.jpg"; break;
                case 263: picture = "263_266_Light drizzle.jpg"; break;
                case 266: picture = "263_266_Light drizzle.jpg"; break;
                case 281: picture = "311_281_314_FreezingDrizzle.jpg"; break;
                case 293: picture = "293_296_353_LightRain.jpg"; break;
                case 296: picture = "293_296_353_LightRain.jpg"; break;
                case 299: picture = "299_302_356_ModerateRain.jpg"; break;
                case 302: picture = "299_302_356_ModerateRain.jpg"; break;
                case 311: picture = "311_281_314_FreezingDrizzle.jpg"; break;
                case 314: picture = "311_281_314_FreezingDrizzle.jpg"; break;
                case 356: picture = "299_302_356_ModerateRain.jpg"; break;
                case 353: picture = "293_296_353_LightRain.jpg"; break;
                case 350: picture = "350_374_377_IcePelets.jpg"; break;
                case 374: picture = "350_374_377_IcePelets.jpg"; break;
                case 377: picture = "350_374_377_IcePelets.jpg"; break;
                case 179: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 182: picture = "182_317_PatchySleet.jpg"; break;
                case 317: picture = "182_317_PatchySleet.jpg"; break;
                case 320: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 323: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 326: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 329: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 332: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 335: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 362: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 365: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 368: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 371: picture = "179_320_323_326_329_332_335_362_365_368_371_PatchySnow.jpg"; break;
                case 119: picture = "119_Cloudy.jpg"; break;
                case 122: picture = "122_Overcast.jpg"; break;
                case 200: picture = "200_386_389_ThunderyOutbreaks.jpg"; break;
                case 386: picture = "200_386_389_ThunderyOutbreaks.jpg"; break;
                case 389: picture = "200_386_389_ThunderyOutbreaks.jpg"; break;
                case 392: picture = "392_395_SnowWithThunder.jpg"; break;
                case 395: picture = "392_395_SnowWithThunder.jpg"; break;
                case 248: picture = "248_Fog.jpg"; break;
                case 260: picture = "260_FreezingFog.jpg"; break;
                case 305: picture = "305_308_359_HeavyRain.jpg"; break;
                case 308: picture = "305_308_359_HeavyRain.jpg"; break;
                case 359: picture = "305_308_359_HeavyRain.jpg"; break;
                case 227: picture = "227_BlowingSnow.jpg"; break;
                case 230: picture = "230_338_Blizzard.jpg"; break;
                case 284: picture = "284_HeavyFreezingDrizzle.jpg"; break;
                case 338: picture = "230_338_Blizzard.jpg"; break;
                default:picture = "Null"; break;
            }
            return "./images/" + picture;
        }
        private string getCzechDescription() {
            string description = "";
            switch (weather_code) {
                case 113: description = "Slunečno"; break;
                case 116: description = "Částečně oblačno"; break;
                case 143: description = "Opar"; break;
                case 176: description = "Místy déšť"; break;
                case 185: description = "Místy  mrznoucí mrholení"; break;
                case 263: description = "Místy slabé mrholení"; break;
                case 266: description = "Slabé mrholení"; break;
                case 281: description = "Mrznoucí mrholení"; break;
                case 293: description = "Místy slabý déšť"; break;
                case 296: description = "Slabý déšť"; break;
                case 299: description = "Občasný mírný déšť"; break;
                case 302: description = "Mírný déšť"; break;
                case 311: description = "Slabý mrznoucí déšť"; break;
                case 314: description = "Mírný nebo silný mrznoucí déšť"; break;
                case 356: description = "Středně silný nebo silný déšť"; break;
                case 353: description = "Lehký déšť"; break;
                case 350: description = "Ledové kroupy"; break;
                case 374: description = "Slabé přeháňky s ledovými kroupami"; break;
                case 377: description = "Středně silné nebo silné přeháňky s ledovými kroupami"; break;
                case 179: description = "Místy sněžení"; break;
                case 182: description = "Místy déšť se sněhem"; break;
                case 317: description = "Lehký déšť se sněhem"; break;
                case 320: description = "Středně silný nebo silný déšť se sněhem"; break;
                case 323: description = "Slabé slabé sněžení"; break;
                case 326: description = "Slabé sněžení"; break;
                case 329: description = "Občasné mírné sněžení"; break;
                case 332: description = "Mírné sněžení"; break;
                case 335: description = "Místy silné sněžení"; break;
                case 362: description = "Slabé přeháňky se sněhem"; break;
                case 365: description = "Středně silné nebo silné přeháňky se sněhem"; break;
                case 368: description = "Slabé sněhové přeháňky"; break;
                case 371: description = "Mírné nebo silné sněhové přeháňky"; break;
                case 119: description = "Oblačno"; break;
                case 122: description = "Zataženo"; break;
                case 200: description = "V okolí možnosti vzniku bouřek"; break;
                case 386: description = "Občasný slabý déšť v oblasti s bouřkami"; break;
                case 389: description = "Mírný nebo silný déšť v oblasti s bouřkami"; break;
                case 392: description = "Místy slabé sněžení v oblasti s bouřkami"; break;
                case 395: description = "Mírné nebo silné sněžení v oblasti s bouřkami"; break;
                case 248: description = "Mlha"; break;
                case 260: description = "Mrznoucí mlha"; break;
                case 305: description = "Občasný silný déšť"; break;
                case 308: description = "Silný déšť"; break;
                case 359: description = "Přívalová dešťová přeháňka"; break;
                case 227: description = "Vítr se sněžením"; break;
                case 230: description = "Sněhová bouře"; break;
                case 284: description = "Silné mrznoucí mrholení"; break;
                case 338: description = "Silné sněžení"; break;
                default: description = "Null"; break;
            }
            return description;
        }
    }
}
