import http from '../http-common';

class ContactsDataService {
    getAll() {
        return http.get('/contacts');
    }
    get(id) {
        return http.get(`/contacts/${id}`);
    }
    create(data) {
        return http.post('/contacts', data);
    }
    update(data) {
        return http.put('/contacts', data);
    }
    delete(id) {
        return http.delete(`/contacts/${id}`);
    }
    getCompanyAll() {
        return http.get('/companies');
    }
    getPositionAll() {
        return http.get('/positions');
    }
}

export default new ContactsDataService();