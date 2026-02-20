import { Component, signal } from '@angular/core';

interface Monkey {
    id: string;
    name: string;
    species: string;
}

@Component({
    selector: 'app-monkey-list',
    standalone: true,
    templateUrl: './monkey-list.component.html',
    styleUrl: './monkey-list.component.css'
})
export class MonkeyListComponent {
    monkeys = signal<Monkey[]>([
        { id: '1', name: 'George', species: 'Capuchin' },
        { id: '2', name: 'Koko', species: 'Gorilla' },
        { id: '3', name: 'Caesar', species: 'Chimpanzee' }
    ]);
}
