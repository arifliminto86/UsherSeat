class SeatDto {
    column: number;
    x: number;
    y:number;
    isOccupied: boolean;
    isDisabled: boolean;   

    constructor() {
        this.isOccupied = false;
        this.isDisabled = false;
    }
}
