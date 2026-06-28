
let flights = [];

function getInitialFlights() {
    return [
        { time: '08:30', flight: 'AA101', dest: 'New York', gate: 'A12', status: 'ON TIME' },
        { time: '09:15', flight: 'BA202', dest: 'London', gate: 'B04', status: 'BOARDING' },
        { time: '10:00', flight: 'LH303', dest: 'Berlin', gate: 'C08', status: 'ON TIME' },
        { time: '11:45', flight: 'AF404', dest: 'Paris', gate: 'D11', status: 'DELAYED' },
        { time: '12:30', flight: 'EK505', dest: 'Dubai', gate: 'E02', status: 'ON TIME' },
    ];
}

const board = document.getElementById('board');
const clockEl = document.getElementById('clock');
const counterEl = document.getElementById('counter');


function renderBoard() {
    board.innerHTML = '';

    flights.forEach(function(f, i) {
        const row = document.createElement('div');
        row.className = 'row row-enter';
        row.style.animationDelay = (i * 20) + 'ms';

        const cells = [
            f.time,
            f.flight,
            f.dest,
            f.gate,
            f.status
        ];

        cells.forEach(function(val, idx) {
            const span = document.createElement('span');
            span.textContent = val;
            if (idx === 4) {
                span.className = 'status ' + getStatusClass(val);
            }
            row.appendChild(span);
        });

        board.appendChild(row);
    });

    updateCounter();
}


function getStatusClass(status) {
    const map = {
        'ON TIME': 'status-on-time',
        'BOARDING': 'status-boarding',
        'GATE CLOSED': 'status-gate-closed',
        'DEPARTED': 'status-departed',
        'DELAYED': 'status-delayed',
        'CANCELLED': 'status-cancelled',
    };
    return map[status] || 'status-on-time';
}



function updateCounter() {
    const total = flights.length;
    const boarding = flights.filter(f => f.status === 'BOARDING').length;
    const delayed = flights.filter(f => f.status === 'DELAYED').length;
    let label = total + ' flights';
    if (boarding) label += ' · ' + boarding + ' boarding';
    if (delayed) label += ' · ' + delayed + ' delayed';
    counterEl.textContent = label;
}



function addRandomFlight() {
    const times = ['06:45', '07:20', '08:10', '09:00', '10:30', '11:15', '12:50', '13:40', '14:25', '15:10', '16:00', '17:20'];
    const dests = ['Tokyo', 'Sydney', 'Mumbai', 'Toronto', 'Singapore', 'Cairo', 'Amsterdam', 'Bangkok'];
    const gates = ['A3', 'B7', 'C2', 'D9', 'E4', 'F1', 'G8', 'H5'];
    const statuses = ['ON TIME', 'ON TIME', 'ON TIME', 'BOARDING', 'DELAYED'];

    const newFlight = {
        time: times[Math.floor(Math.random() * times.length)],
        flight: 'FL' + String(Math.floor(Math.random() * 900) + 100),
        dest: dests[Math.floor(Math.random() * dests.length)],
        gate: gates[Math.floor(Math.random() * gates.length)],
        status: statuses[Math.floor(Math.random() * statuses.length)],
    };

    flights.push(newFlight);
    renderBoard();
}



document.getElementById('addBtn').addEventListener('click', addRandomFlight);

document.getElementById('resetBtn').addEventListener('click', function() {
    flights = getInitialFlights();
    renderBoard();
});

document.getElementById('customAddBtn').addEventListener('click', function() {
    const f = document.getElementById('flightInput');
    const d = document.getElementById('destInput');
    const g = document.getElementById('gateInput');

    if (!f.value.trim() || !d.value.trim() || !g.value.trim()) {
        alert('Please fill in all fields.');
        return;
    }

    const now = new Date();
    const time = String(now.getHours()).padStart(2, '0') + ':' + String(now.getMinutes()).padStart(2, '0');

    flights.push({
        time: time,
        flight: f.value.trim().toUpperCase(),
        dest: d.value.trim(),
        gate: g.value.trim().toUpperCase(),
        status: 'ON TIME',
    });

    f.value = '';
    d.value = '';
    g.value = '';
    renderBoard();
});

function tickClock() {
    const now = new Date();
    clockEl.textContent =
        String(now.getHours()).padStart(2, '0') + ':' +
        String(now.getMinutes()).padStart(2, '0');
}

tickClock();
setInterval(tickClock, 10000);

function advanceStatus(current) {
    const chain = ['ON TIME', 'BOARDING', 'GATE CLOSED', 'DEPARTED'];
    const idx = chain.indexOf(current);
    if (idx === -1 || idx === chain.length - 1) return current;
    return chain[idx + 1];
}

setInterval(function() {
    if (!flights.length) return;

    const idx = Math.floor(Math.random() * flights.length);
    const f = flights[idx];
    const next = advanceStatus(f.status);

    if (next !== f.status) {
        f.status = next;
        renderBoard();
    }
}, 5000);

flights = getInitialFlights();
renderBoard();