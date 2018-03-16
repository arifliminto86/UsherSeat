/// <reference path="../typings/jquery/jquery.d.ts" />
class SeatLogic
{
    private models: Array<SeatDto> = [];

    /*
     * Default constant value
     */
    private readonly defaultColumnConst: number = 5;
    private readonly defaultRowConst: number = 5;
    private readonly defaultTotalSeatsPerRow: number = 4;
    
    /*
     * Default Url of the web api
     */
    url: string = 'http://localhost:54392/api/seat/';

    constructor(urlParameter)
    {
        this.url = urlParameter;
        this.models = new Array<SeatDto>();
    }

    /**
     * Build Seat dynamically Html
     */
    public buildSeatsHtml() :string {
        var htmlResult: string = "";

        htmlResult += "<table class='table table-stripped'>";
        // iterate each rows
        for (let row = 0; row < this.defaultRowConst-1; row++)
        {
            htmlResult += "<tr>";
            //iterate each rows
            for (let column = 0; column < this.defaultColumnConst; column++) {
                htmlResult += "<td>";    
                var seats = this.buildSeatRowUi(column, row, this.defaultTotalSeatsPerRow);
                htmlResult += seats;
                htmlResult += "</td>";
            }
            htmlResult += "</tr>";            
        }
        return htmlResult;
    }

    /**
     * Build seat per row in UI
     * @param column which column that we build
     * @param row which row
     * @param totalSeats total seats per row
     */
    public buildSeatRowUi(column: number, row: number, totalSeats: number): string {

        var seats: string = "";

        for (let i = 0; i < this.defaultTotalSeatsPerRow; i++) {
            seats += "<td>";
            seats += this.buildSeatUi(column, i, row);
            seats += "</td>";
        }
        var str: string = "<table class='table table-stripped'><tr>" + seats + "</tr></table>";
        return str;

    }

    /**
     * Build one single seat UI and push the seat into model
     * @param column
     * @param x
     * @param y
     */
    public buildSeatUi(column: number, x: number, y: number): string {
        let seat = new SeatDto();
        seat.column = column;
        seat.x = x;
        seat.y = y;

        this.models.push(seat);

        var idstr = "column_" + column + "_" + x + "_"+ y;
        var str = " <label id='" + idstr + "' class='label label-success' " +
                  " onclick=_service.occupySeatUi('"+idstr+"')>X</label> ";
        return str;        
    }


    public occupySeatUi(htmlSeatId: string) {

        //parse htmlseatid added "" to make sure the htmlseatid  are string
        var rawhtmls = (""+htmlSeatId).split('column_',2);
        //parse again the lastelement
        var rawseats = (""+rawhtmls[1]).split('_',3);

        var column: number = Number(""+rawseats[0]);
        var x: number = Number("" + rawseats[1]);
        var y: number = Number("" + rawseats[2]);

        //typescript does not realy work with jquery therefore, i need to use document.getelementbyid
        if (this.occupySeat(column, x, y)) {
            
            document.getElementById(htmlSeatId).innerText = "O";
            document.getElementById(htmlSeatId).classList.remove("label-success");
            document.getElementById(htmlSeatId).classList.add("label-danger");
        }
        else
        {
            document.getElementById(htmlSeatId).innerText = "X";            
            document.getElementById(htmlSeatId).classList.remove("label-danger");
            document.getElementById(htmlSeatId).classList.add("label-success");            
        }
    }

    /**
     * check if seat is already occupied and
     * if not,  Add new seat and set it to be occupied and save it to the database
     * @param column : which column that has been occupied
     * @param x : x coordinate
     * @param y : y coordinate
     */
    public occupySeat(column:number, x: number, y: number): boolean {
        
        for (let i = 0; i < this.models.length; i++) {
            if (this.models[i].column === column && this.models[i].x === x && this.models[i].y === y)
            {
                if (this.models[i].isOccupied === false) {
                    this.models[i].isOccupied = true;
                    return true;
                } else {
                    this.models[i].isOccupied = false;
                    return false;
                }                
            }
        }
        return true;
    }

    /**
     * Check if seat is already occupied
     * @param column
     * @param x
     * @param y
     */
    public isOccupied(column: number, x: number, y: number): boolean {
        var seat = this.getSeat(column, x, y);

        if (seat == null)
        {
            throw new TypeError("Seat is not exist");
        }

        if (seat.isOccupied)
        {
            return true;
        }

        return false;
    }


    public getSeat(column: number, x: number, y: number): SeatDto
    {
        for (let i = 0; i < this.models.length; i++)
        {
            if (this.models[i].column === column && this.models[i].x === x && this.models[i].y === y)
            {                
                return this.models[i];                
            }
        }
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