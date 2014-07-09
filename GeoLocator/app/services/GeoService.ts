module App.Services {
    export interface ILocation {
        postalcode: string;
        name: string;
        lat: number;
        lng: number;
        adminName1: string;
        adminName2: string;
    }

    export class GeoService {
        constructor(public $http: ng.IHttpService) { }

        getLocationByZip(zip: string): ng.IHttpPromise<ILocation> {
            return this.$http.get<ILocation>("http://api.geonames.org/postalCodeSearch?postalcode=" + zip + "&username=eclipseroll");
        }
    }

    container.service("GeoService", GeoService);
} 