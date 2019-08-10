
import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http'; 
import { PriorityModel, ScopeModel, SprintModel, SuccessRateModel, VelocityTrendsModel, StoryPointMappingModel, PriorityForecastModel} from '../../apimodel'

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html'
})
export class CounterComponent {
    public velocityForecast: MetricsForecast;
    public priorityForecastModel: MetricsForecast;
    public acceptedForecastModel: MetricsForecast;
    public scopechangeForecastModel: MetricsForecast;
    public chartLegend: boolean = true;
    public chartType: string = 'bar';


    public chartOptions: any = {
        responsive: true,
        legend: {
            position: 'bottom'
        }
    };

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/metrics/velocity/trends').subscribe(result => {
            
            this.velocityForecast = result.json() as MetricsForecast;
        }, error => console.error(error)); 
        http.get(baseUrl + 'api/metrics/priority').subscribe(result => {
           
            this.priorityForecastModel = result.json() as MetricsForecast;
        }, error => console.error(error)); 
        http.get(baseUrl + 'api/metrics/successrate/data').subscribe(result => {
            
            this.acceptedForecastModel = result.json() as MetricsForecast;
        }, error => console.error(error));
        http.get(baseUrl + 'api/metrics/scope/data').subscribe(result => {
           
            this.scopechangeForecastModel = result.json() as MetricsForecast;
        }, error => console.error(error)); 
    }
}


interface Metrics {
    data: Array<number>;
    label: string;
}

interface MetricsForecast {
    weatherList: Metrics[];
    chartLabels: string[];
}  
