<template>
    <div class="container-fluid mt-4">
        <div class="row">
            <div class="search-wrapper panel-heading col-sm-12">
                <input class="form-control" type="text" v-model="searchQuery" placeholder="Search" />
            </div>
        </div>
        <h1 class="h1">Contacts:</h1>
        <div class="row">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>EmploymentDate</th>
                        <th>Company</th>
                        <th>Position</th>
                        <th>OnHoliday</th>
                        <th>&nbsp;</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="contact in resultQuery" :key="contact.id">
                        <td>{{ contact.name }}</td>
                        <td>{{ contact.employmentDate | formatDate }}</td>
                        <td>{{ contact.company.name }}</td>
                        <td>{{ contact.position.name }}</td>
                        <td>
                            <input class="form-check-input" type="checkbox" v-model="contact.isOnHoliday" disabled>
                        </td>
                        <td class="text-right">
                            <router-link :to="{name: 'contact', params: {id:contact.id}}" class="text-dark">Edit</router-link>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="alert alert-primary" role="alert" v-show="loading">Loading...</div>
        <router-link to="/add" class="btn btn-primary">Add</router-link>
    </div>
</template>

<script>
    import ContactsDataService from '../services/ContactsDataService';

    export default {
        data() {
            return {
                searchQuery: null,
                loading: false,
                contacts: []
            }
        },
        methods: {
            loadContacts() {
                this.loading = true;
                ContactsDataService.getAll()
                    .then(rs => { this.contacts = rs.data; this.loading = false; })
                    .catch(e => { console.log(e); });
            }
        },
        mounted: function () {
            this.loadContacts();
        },
        computed: {
            resultQuery() {
                if (this.searchQuery) {
                    return this.contacts.filter((item) => {
                        return this.searchQuery.toLowerCase().split(' ')
                            .every(v => item.name.toLowerCase().includes(v))
                    })
                } else {
                    return this.contacts;
                }
            }
        }

    }
</script>