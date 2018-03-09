/// <reference path="../typings/jquery/jquery.d.ts" />
class SeatLogic
{

    private models:Array<SeatDto> = [];

    /*
     * Url of the web api
     */
    url: string = 'http://localhost:54392/api/seat/';

    constructor(urlParameter)
    {
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
     * @param column : which column that has been occupied
     * @param x : x coordinate
     * @param y : y coordinate
     */
    public occupySeat(column:number, x: number, y: number) {

        if (this.isOccupied(column, x, y) === false) {

        } else {
            alert("The seat is already occupied");
        }
    }

    /**
     * Check if seat is already occupied
     * @param column
     * @param x
     * @param y
     */
    public isOccupied(column: number, x: number, y: number): boolean {
        var seat = this.getSeat(column, x, y);

        if (seat) {
            throw new TypeError("Seat is not exist");
        }

        if (seat.isOccupied) {
            return true;
        }

        return false;
    }


    public getSeat(column: number, x: number, y: number): SeatDto {

        this.models.forEach(
            value =>
            {
                if (value.column === column && value.x === x && value.y === y)
                {
                    return value;
                }
            });

        return null;
    }

    /**
     * Refresh the dash board periodicly from web api
     */
    public refreshDashboard() {
        
        $.ajax(
            {
                url: this.url,
                dataType: 'json',
                cache: false,
                success(result) {
                },

            }).done(results =>
            {
                //parse it into models                    
                this.models.length = 0; //clear array

                for (var i = 0; i < results.length-1; i++) {

                    let seat = new SeatDto();
                    seat.column = results[i].column;
                    seat.x = results[i].Position.x;
                    seat.y = results[i].Position.y;
                    seat.isOccupied = results[i].isOccupied;
                    seat.isDisabled = results[i].isDisabled;
                    this.models.push(seat);
                }
                
            });
        
    }    
};