/// <reference path="../typings/jquery/jquery.d.ts" />
class SeatLogic {

    public models:Array<SeatDto> = [];

    /*
     * Url of the web api
     */
    url : string;

    constructor(urlParameter) {
        this.url = urlParameter;
        this.models = new Array<SeatDto>();
    }

    /**
     * build default seats
     */
    buildSeat() {
        
    }

    /**
     * check if seat is already occupied and
     * if not,  Add new seat and set it to be occupied and save it to the database
     * @param column
     * @param x
     * @param y
     */
    occupiedSeat(column:number, x: number, y: number) {

        if (this.isOccupied(column, x, y) === false) {

        } else {
            alert("The seat is already occupied");
        }
    }

    isOccupied(column: number, x: number, y: number): boolean {
        return false;
    }

    /**
     * Refresh the dash board periodicly from web api
     */
    refreshDashboard() {
        $.ajax(
            {
                url: this.url,
                dataType: 'json',
                cache: false,
                success(result) {
                },

            }).done(results => {
            //parse it into models                    
            this.models.length = 0; //clear array

            for (var i = 0; i < results.length-1; i++) {

                let seat = new SeatDto();
                seat.column = results[i].column;
                seat.row = results[i].row;
                seat.isOccupied = results[i].isOccupied;
                seat.isDisabled = results[i].isDisabled;
                this.models.push(seat);
            }
                
        });
        
    }
};