import Vue from 'vue';
import Router from 'vue-router';

import Contacts from '../components/Contacts.vue'
import Contact from '../components/Contact.vue'
import AddContact from '../components/AddContact.vue'

Vue.use(Router);

export default new Router({
    mode: 'history',
    routes: [
        {
            path: '/contacts',
            name: 'contacts',
            component: Contacts
        },
        {
            path: '/contacts/:id',
            name: 'contact',
            component: Contact
        },
        {
            path: '/add',
            name: 'addcontact',
            component: AddContact
        }
    ]
});