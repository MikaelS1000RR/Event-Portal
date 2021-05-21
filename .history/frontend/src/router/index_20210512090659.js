import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import CreateEvent from '../views/CreateEvent.vue'
import Details from '../views/Details.vue'
import MyCreatedEvents from '../views/MyCreatedEvents.vue'

import UpdateEvent from '../views/UpdateEvent.vue'

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
    path: '/details/:id',
    name: 'Details',
    component: Details
  },
  {
    path: '/update-event/:id',
    name: 'Update-event',
    component: UpdateEvent
  },

  {
    path: '/m'
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
