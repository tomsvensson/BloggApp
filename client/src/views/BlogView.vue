<template>
    <div class="blog-container">
        <header>
            <h1>Min Blogg</h1>
        </header>

        <section class="entries-list">
            <EntriesList :key="entriesKey" />
        </section>

        <section class="new-entry">
            <h2>Skapa ett nytt inlägg</h2>
            <form @submit.prevent="saveEntry">
                <input type="text" placeholder="Titel" v-model="title" maxlength="100" required> <br>
                <textarea placeholder="Innehåll" v-model="content" maxlength="5000" required></textarea> <br>
                <input type="datetime-local" v-model="date" required> <br>
                <button type="submit">Spara</button>
            </form>
        </section>
    </div>
</template>

<script>
import EntriesList from '@/components/EntriesList.vue'

export default {
    components: {
        EntriesList
    },

    data() {
        return {
            title: "",
            content: "",
            date: this.getCurrentDateTime(), 
            entriesKey: 0
        }
    },

    methods: {
        getCurrentDateTime() {
            const now = new Date();
            return now.toISOString().slice(0, 16); 
        },

        saveEntry() {
            if (!this.title || !this.content || !this.date) {
                alert("Alla fält är obligatoriska.");
                return;
            }

            const entry = {
                title: this.title,
                content: this.content,
                date: this.date
            };

            fetch('http://localhost:5189/api/Entries', {
                method: 'POST',
                body: JSON.stringify(entry),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(() => {
                this.entriesKey++; 
                this.title = "";
                this.content = "";
                this.date = this.getCurrentDateTime(); 
            });
        }
    }
}
</script>

<style scoped>
.blog-container {
    max-width: 800px;
    margin: 0 auto;
    font-family: Arial, sans-serif;
    line-height: 1.6;
}

header {
    text-align: center;
    margin-bottom: 20px;
}

.entries-list {
    margin-bottom: 40px;
}

.new-entry {
    background: #f9f9f9;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}

.new-entry h2 {
    margin-bottom: 10px;
}

.new-entry form input,
.new-entry form textarea {
    width: 100%;
    margin-bottom: 10px;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 4px;
}

.new-entry form textarea {
    height: 100px;
}

.new-entry form button {
    background: #42b983;
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 4px;
    cursor: pointer;
}

.new-entry form button:hover {
    background: #369f6b;
}
</style>