<template>
    <div class="view-entry-container">
        <header>
            <h1>{{ entry.title }}</h1>
        </header>

        <section class="entry-content">
            <p>{{ entry.content }}</p>
        </section>
        <section class="entry-date">
            <p>{{ formatDate(entry.date) }}</p>
        </section>

        <div class="actions">
            <router-link :to="'/edit/' + entry.id" class="edit-button">Redigera inlägg</router-link>

        </div>

        <div class="go-back">
            <button @click="goBack" class="back-button">Tillbaka</button>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            entry: {}
        }
    },

    created() {
        const id = this.$route.params.id;

        fetch('http://localhost:5189/api/Entries/' + id)
            .then(data => data.json())
            .then(entry => {
                this.entry = entry;
            });
    },

    methods: {
        formatDate(date) {
            return new Date(date).toLocaleDateString();
        },

        goBack() {
            this.$router.go(-1); 
        },

        deleteEntry() {
            const id = this.$route.params.id;

            if (confirm("Är du säker på att du vill ta bort detta inlägg?")) {
                fetch('http://localhost:5189/api/Entries/' + id, {
                    method: 'DELETE'
                })
                .then(() => {
                    this.$router.push('/');
                });
            }
        }
    }
}
</script>

<style scoped>
.view-entry-container {
    max-width: 800px;
    margin: 0 auto;
    font-family: Arial, sans-serif;
    line-height: 1.6;
    background: #fff;
    padding: 20px;
    border-radius: 8px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    margin-top: 30px;
}

header {
    text-align: center;
    margin-bottom: 20px;
}

.entry-date {
    font-size: 0.9em;
    color: #888;
    margin-bottom: 20px;
}

.entry-content {
    font-size: 1.2em;
    color: #333;
    margin-bottom: 20px;
}

.actions {
    text-align: center;
    margin-bottom: 20px;
}

.edit-button {
    background: #42b983;
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 4px;
    text-decoration: none;
    cursor: pointer;
    margin-right: 10px;
}

.edit-button:hover {
    background: #369f6b;
}

.delete-button {
    background: #e74c3c;
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 4px;
    cursor: pointer;
}

.delete-button:hover {
    background: #c0392b;
}

.go-back {
    text-align: center;
    margin-top: 20px;
}

.back-button {
    background: #42b983;
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 4px;
    cursor: pointer;
}

.home-button:hover {
    background: #369f6b;
}
</style>