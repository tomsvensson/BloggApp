<template>
    <div class="entries-list">
        <router-link 
            v-for="entry in entries" 
            :key="entry.id" 
            :to="'/view/' + entry.id" 
            class="entry-link"
        >
            <article class="entry">
                <h2>{{ entry.title }}</h2>
                <p class="entry-content">{{ entry.content.substring(0, 200) }}{{entry.content.length>200?"...":""}}</p>
                <p class="entry-date">{{ formatDate(entry.date) }}</p>
            </article>
        </router-link>
    </div>
</template>

<script>
export default {
    name: 'EntriesList',

    data() {
        return {
            entries: []
        }
    },

    created() {
        fetch('http://localhost:5189/api/Entries')
            .then(data => data.json())
            .then(entries => {
                this.entries = entries; 
            });
    },

    methods: {
        formatDate(date) {
            return new Date(date).toLocaleDateString();
        }
    }
}
</script>

<style scoped>
.entries-list {
    display: flex;
    flex-direction: column;
    gap: 20px;
}

.entry-link {
    text-decoration: none;
    color: inherit;
}

.entry {
    padding: 20px;
    border: 1px solid #ddd;
    border-radius: 8px;
    background: #fff;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    transition: transform 0.2s, box-shadow 0.2s;
}

.entry:hover {
    transform: translateY(-2px);
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.entry h2 {
    margin: 0 0 10px;
}

.entry-date {
    font-size: 0.9em;
    color: #888;
    margin-bottom: 10px;
}

.entry-content {
    font-size: 1em;
    color: #333;
}
</style>