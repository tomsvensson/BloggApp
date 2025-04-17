import { createRouter, createWebHashHistory } from 'vue-router'
import BlogView from '../views/BlogView.vue'
import ViewEntryView from '../views/ViewEntryView.vue'
import EditEntryView from '../views/EditEntryView.vue'

const routes = [
  {
    path: '/',
    name: 'blog',
    component: BlogView
  },
  {
    path: '/view/:id',
    name: 'viewEntry',
    component: ViewEntryView
  },
  {
    path: '/edit/:id',
    name: 'editEntry',
    component: EditEntryView
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
