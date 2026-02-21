import { Component, resource, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

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
    imports: [CommonModule, FormsModule],
    templateUrl: './monkey-list.component.html',
    styleUrl: './monkey-list.component.css'
})
export class MonkeyListComponent {
    monkeysData = resource({
        loader: async () => {
            const res = await fetch('http://localhost:5099/api/monkeys');
            if (!res.ok) throw new Error('Failed to load monkeys');
            const data = await res.json() as GetMonkeysResponse;
            return data.monkeys;
        }
    });

    name = signal('');
    age = signal<number | null>(null);
    temperament = signal('Playful');
    isSubmitting = signal(false);

    readonly temperaments = ['Playful', 'Calm', 'Aggressive', 'Shy', 'Curious'];

    async addMonkey(event: Event) {
        event.preventDefault();
        if (!this.name() || !this.age()) return;

        this.isSubmitting.set(true);
        try {
            const res = await fetch('http://localhost:5099/api/monkeys', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    name: this.name(),
                    age: this.age(),
                    temperament: this.temperament()
                })
            });

            if (res.ok) {
                this.name.set('');
                this.age.set(null);
                this.temperament.set('Playful');
                this.monkeysData.reload();
            }
        } finally {
            this.isSubmitting.set(false);
        }
    }

    async deleteMonkey(id: string) {
        if (!confirm('Are you sure you want to delete this monkey?')) return;

        try {
            const res = await fetch(`http://localhost:5099/api/monkeys/${id}`, {
                method: 'DELETE'
            });

            if (res.ok) {
                this.monkeysData.reload();
            }
        } catch (e) {
            console.error('Failed to delete monkey', e);
        }
    }
}
