class Holiday {
    constructor(destination, days) {
        this.destination = destination
        this.days = days
    }

    info() {

        console.log(`${this.destination} stay for ${this.days} days`)
    }
}

class ExpeditionHolidays extends Holiday {

    constructor(destination, days, gear) {
        super(destination, days);
        this.gear = gear;
    }

    info() {
        super.info();
        console.log(`bring your ${this.gear.join(',')} as well`)
    }

}

const tripWithGear = new ExpeditionHolidays('Everest', 20, ["Sunglasses", "Hiking Shoes", "Snow Stick"])
tripWithGear.info();