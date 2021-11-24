<template>
    <div class="container-fluid mt-4">
        <h1 class="h1">New Contact</h1>
        <form class="submit-form">
            <div v-if="!submitted">
                <div class="form-group">
                    <label>Name</label>
                    <input type="text" class="form-control" required v-model="contact.name"/>
                </div>

                <div class="form-group">
                    <label>EmploymentDate</label>
                    <input type="date" class="form-control" required v-model="contact.employmentDate" />
                </div>

                <div class="form-group">
                    <label>Company</label>
                    <select class="form-control" v-model="contact.companyId">
                        <option v-for="company in companies" v-bind:value="company.id">{{company.name}}</option>
                    </select>
                </div>

                <div class="form-group">
                    <label>Position</label>
                    <div class="form-check" v-for="position in positions">
                        <input type="radio" class="form-check-input" v-bind:value="position.id" v-model="contact.positionId" />
                        <label class="form-check-label">{{ position.name }}</label>
                    </div>
                </div>

                <div class="form-group">
                    <label>OnHoliday</label>
                    <input type="checkbox" class="form-check-input" required v-model="contact.isOnHoliday" />
                </div>

                <button @click="saveContact" class="btn btn-primary">Submit</button>
                <a class="btn btn-success" v-bind:href="'/contacts'">Back to Contacts</a>
            </div>

            <div v-else>
                <h4>You submitted successfully!</h4>
                <a class="btn btn-success" v-bind:href="'/contacts'">Back to Contacts</a>
            </div>
        </form>
    </div>
</template>

<script>
    import ContactsDataService from '../services/ContactsDataService';

    export default {
        data() {
            return {
                loading: false,
                companies: [],
                positions: [],
                contact: {
                    name: '',
                    employmentDate: null,
                    companyId: null,
                    positionId: null,
                    isOnHoliday: false
                },
                submitted: false
            }
        },
        methods: {
            loadCompanies() {
                this.loading = true;
                ContactsDataService.getCompanyAll()
                    .then(rs => { this.companies = rs.data; console.log(this.companies); })
                    .catch(e => { console.log(e); });
            },
            loadPositions() {
                this.loading = true;
                ContactsDataService.getPositionAll()
                    .then(rs => { this.positions = rs.data; console.log(this.companies); })
                    .catch(e => { console.log(e); });
            },
            saveContact() {
                ContactsDataService.create(this.contact)
                    .then(response => { this.submitted = true; })
                    .catch(e => { console.log(e); });
            },
        },
        mounted: function () {
            this.loadCompanies();
            this.loadPositions();
        }
    }
</script>