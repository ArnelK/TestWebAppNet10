import { Component, resource } from '@angular/core';

interface MonkeyDto {
    id: string;
    name: string;
    age: number;
    temperament: string;
}

interface GetMonkeysResponse {
    monkeys: MonkeyDto[];
}

@Component({
    selector: 'app-monkey-list',
    standalone: true,
    templateUrl: './monkey-list.component.html',
    styleUrl: './monkey-list.component.css'
})
export class MonkeyListComponent {
    monkeysData = resource({
        loader: async () => {
            const res = await fetch('http://localhost:5149/api/monkeys');
            const data = await res.json() as GetMonkeysResponse;
            return data.monkeys;
        }
    });
}
