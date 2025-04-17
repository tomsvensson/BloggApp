<template>
    <div class="edit-entry-container">
        <header>
            <h1>Redigera inlägg</h1>
        </header>

        <section class="entry-form">
            <form>
                <label for="title">Titel</label>
                <input id="title" type="text" v-model="title" maxlength="100" required> <br>

                <label for="content">Innehåll</label>
                <textarea id="content" v-model="content" maxlength="5000" required></textarea> <br>

                <label for="date">Datum</label>
                <input id="date" type="datetime-local" v-model="date" required> <br>

                <div class="form-buttons">
                    <button type="button" @click="updateEntry" class="update-button">Uppdatera inlägg</button>
                    <button type="button" @click="deleteEntry" class="delete-button">Ta bort inlägg</button>
                </div>
            </form>
        </section>

        <div class="back-to-home">
            <button @click="goBack" class="home-button">Tillbaka</button>
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            title: "",
            content: "",
            date: ""
        }
    },

    created() {
        const id = this.$route.params.id;

        fetch('http://localhost:5189/api/Entries/' + id)
            .then(data => data.json())
            .then(entry => {
                this.title = entry.title;
                this.content = entry.content;
                this.date = entry.date;
            });
    },

    methods: {
        updateEntry() {
            const entry = {
                title: this.title,
                content: this.content,
                date: this.date
            };

            const id = this.$route.params.id;

            fetch('http://localhost:5189/api/Entries/' + id, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(entry)
            })
            .then(() => {
                this.$router.push('/');
            });
        },

        deleteEntry() {
            const id = this.$route.params.id;

            fetch('http://localhost:5189/api/Entries/' + id, {
                method: 'DELETE'
            })
            .then(() => {
                this.$router.push('/');
            });
        },

        goBack() {
            this.$router.go(-1); 
        }
    }
}
</script>

<style scoped>
.edit-entry-container {
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

.entry-form label {
    display: block;
    font-weight: bold;
    margin-bottom: 5px;
    color: #333;
}

.entry-form input,
.entry-form textarea {
    width: 100%;
    margin-bottom: 15px;
    padding: 10px;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 1em;
}

.entry-form textarea {
    height: 150px;
    resize: vertical;
}

.form-buttons {
    display: flex;
    justify-content: space-between;
}

.update-button {
    background: #42b983;
    color: white;
    border: none;
    padding: 10px 15px;
    border-radius: 4px;
    cursor: pointer;
}

.update-button:hover {
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

.back-to-home {
    text-align: center;
    margin-top: 20px;
}

.home-button {
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