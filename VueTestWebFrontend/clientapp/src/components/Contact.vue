<template>
    <div class="container-fluid mt-4">
        <div v-if="contact" class="edit-form">
            <form>
                <div class="form-group">
                    <label>Name</label>
                    <input type="text" class="form-control" required v-model="contact.name" />
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
            </form>
            <button type="submit" class="btn btn-warning"
                    @click="updateContact">
                Update
            </button>

            <button class="btn btn-danger"
                    @click="deleteContact">
                Delete
            </button>
            <a class="btn btn-success" v-bind:href="'/contacts'">Back to Contacts</a>
        </div>
        <div v-else>
            <alert variant="primary">Loading...</alert>
        </div>
    </div>
</template>

<script>
    import ContactsDataService from '../services/ContactsDataService';
    import moment from 'moment';

    export default {
        data() {
            return {
                contact: null
            }
        },
        methods: {
            loadCompanies() {
                ContactsDataService.getCompanyAll()
                    .then(rs => { this.companies = rs.data; })
                    .catch(e => { console.log(e); });
            },
            loadPositions() {
                this.loading = true;
                ContactsDataService.getPositionAll()
                    .then(rs => { this.positions = rs.data; })
                    .catch(e => { console.log(e); });
            },
            loadContact(id) {
                ContactsDataService.get(id)
                    .then(rs => {
                        rs.data.employmentDate = this.formatDate(rs.data.employmentDate);
                        this.contact = rs.data;
                        console.log(this.contact.employmentDate);
                    })
                    .catch(e => { console.log(e); });
            },
            updateContact() {
                ContactsDataService.update(this.contact)
                    .then(response => { this.$router.push({ name: "contacts" }); })
                    .catch(e => { console.log(e); });
            },
            deleteContact() {
                ContactsDataService.delete(this.contact.id)
                    .then(response => { this.$router.push({ name: "contacts" }); })
                    .catch(e => { console.log(e); });
            },
            formatDate: function (date) {
                return moment(String(date)).format('YYYY-MM-DD');
            }
        },
        mounted: function () {
            this.loadCompanies();
            this.loadPositions();
            this.loadContact(this.$route.params.id);
        }
    }
</script>