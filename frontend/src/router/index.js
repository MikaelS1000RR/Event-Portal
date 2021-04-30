import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import CreateEvent from '../views/CreateEvent.vue'
import Details from '../views/Details.vue'
import LoginPage from '../views/LoginPage'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
{
    path: '/create-event',
    name: 'CreateEvent',
    component: CreateEvent
  },

  {
    path: '/login',
    name: 'LoginPage',
    component: LoginPage
  },

  {
    path: '/details/:id',
    name: 'Details',
    component: Details
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
