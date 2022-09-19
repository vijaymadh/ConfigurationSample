class Holiday {
    constructor(destination, days) {
        this.destination = destination
        this.days = days
    }

    info() {

        console.log(`${this.destination} stay for ${this.days}`)
    }
}


let nepal = new Holiday('Nepal', 50);

nepal.info();