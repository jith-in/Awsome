import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: MetricsForecast[];

    //constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    //    http.get(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //        this.forecasts = result.json() as MetricsForecast[];
    //    }, error => console.error(error));
    //}
    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get( 'http://localhost:55288/Api/Matrix/AllMatrix').subscribe(result => {
            this.forecasts = result.json() as MetricsForecast[];
        }, error => console.error(error));
    }
}

interface MetricsForecast {
    DateFormatted: string;
    TemperatureC: number;
    TemperatureF: number;
    Summary: string;
}
