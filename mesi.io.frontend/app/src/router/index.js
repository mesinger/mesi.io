import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Clipboard from '../views/Clipboard.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/clipboard',
    name: 'Clipboard',
    component: Clipboard
  }
]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
