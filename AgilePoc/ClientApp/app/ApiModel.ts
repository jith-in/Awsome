export class PriorityModel {
    sprintName: string;
    projectName: string;
    issueType: string;
    priority: string;
    priorityCount: number;
}
export class PriorityForecastModel {
    priorityModelList: PriorityModel[];
    chartLegends: string[];
   
}
export class ScopeModel {
    SprintName: string;
    AddedWork: number;
}
export class SprintModel {
    Name: string
    Start: Date;
    End: Date;
    Closed: boolean;
    ProjectName: string;
}
export class StoryPointMappingModel {
    SprintName: string
    CommittedSp: number
    Acceptedsp: number
    ProjectName: string
}
export class SuccessRateModel {
    SprintName: string
    SuccessRate: number;
}
export class VelocityTrendsModel {
    SprintName: string
    Velocity: number;
}