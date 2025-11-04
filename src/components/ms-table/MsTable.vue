<template>
  <div class="main-table-body">
    <table>
      <thead>
        <tr>
          <th><input type="checkbox" /></th>
          <th v-for="tableHeader in tableHeaders" :key="tableHeader">
            {{ tableHeader }}
          </th>
        </tr>
      </thead>
      <tbody>
        <tr class="data-row" v-for="(candidate, index) in candidateData" :key="index">
          <td><input type="checkbox"></td>
          <td>
            <div class="name-with-avatar d-flex align-center">
              <div class="">
                <div class="avatar-circle" :style="{ backgroundColor: candidate.AvatarColor || '#ccc' }">
                  {{ generateAvatar(
                    candidate.CandidateName
                  ) }}
                </div>
              </div>
              <div>{{ checkNull(candidate.CandidateName) }}</div>
            </div>
          </td>
          <td>{{ checkNull(candidate.Mobile) }}</td>
          <td>{{ checkNull(candidate.Email) }}</td>
          <td>{{ checkNull(candidate.RecruitmentCampaignNames) }}</td>
          <td>{{ checkNull(candidate.JobPositionName) }}</td>
          <td>{{ checkNull(candidate.RecruitmentName) }}</td>
          <td>{{ checkNull(candidate.RecruitmentRoundName) }}</td>
          <td>{{ checkNull(candidate.Score) }}</td>
          <td>{{ formatDate(candidate.ApplyDate) }}</td>
          <td>{{ checkNull(candidate.ChannelName) }}</td>
          <td>{{ checkNull(candidate.EducationDegreeName) }}</td>
          <td>{{ checkNull(candidate.EducationPlaceName) }}</td>
          <td>{{ checkNull(candidate.EducationMajorName) }}</td>
          <td>{{ checkNull(candidate.WorkPlaceRecent) }}</td>
          <td>{{ checkNull(candidate.OrganizationUnitName) }}</td>
          <td>{{ checkNull(candidate.Overall) }}</td>
          <td>{{ checkNull(candidate.AreaName) }}</td>
          <td>{{ checkNull(candidate.PresenterName) }}</td>
          <td>{{ checkProbationInfoStatus(
            candidate.ProbationInfoStatus
          ) }}</td>
          <td>{{ checkIsTalentPoolDetail(
            candidate.IsTalentPoolDetail
          ) }}</td>
          <td>{{ checkNull(candidate.AccountPortal) }}</td>
          <td>{{ checkNull(candidate.TagInfos) }}</td>
          <td>{{ checkNull(candidate.CandidateStatusName) }}</td>
          <td>{{ formatGender(candidate.Gender) }}</td>
          <td>{{ formatDate(candidate.Birthday) }}</td>
          <td>{{ checkNull(candidate.Address) }}</td>
          <td>{{ checkNull(candidate.ReasonRemoved) }}</td>
          <td>{{ checkNull(candidate.CollaboratorName) }}</td>
          <td>{{ formatDate(candidate.HireDate) }}</td>
          <td>{{ formatOfferStatus(candidate.OfferStatus) }}</td>
          <td class="action-cell">
            <div class="action-buttons d-flex">
              <button class="btn-edit" aria-label="Sửa" @click="handleEditCandidate(index)">
                <div class="icon__right icon icon-update"></div>
              </button>
              <button class="btn-delete" aria-label="Xóa">
                <div class="icon__right icon icon-delete"></div>
              </button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
  <div class="main-table-footer d-flex justify-space-between align-center">
    <div class="footer-sum-record font-14px">Tổng: <b>{{ candidateData.length }}</b> bản ghi</div>
    <div class="footer-pagging d-flex align-center">
      <div class="mr-10">
        Số bản ghi/trang
      </div>
      <ms-select v-model="paggingValue" :pagging-options="paggingOptions" class="paging-selector" />
      <div class="mr-10">
        1 - 25 bản ghi
      </div>
      <div class="icon icon-arrow-left cursor-pointer mr-10"></div>
      <div class="icon icon-arrow-right cursor-pointer"></div>
    </div>
  </div>
</template>

<script setup>
import { formatDate, formatGender, checkIsTalentPoolDetail, checkProbationInfoStatus, formatOfferStatus, checkNull, generateAvatar } from '@/utils/formatOutput.js';
import { paggingOptions } from '@/utils/constants.js';
import MsSelect from '@/components/ms-selection/MsSelection.vue';

defineProps({
  candidateData: {
    type: Array,
    default: () => []
  },
  tableHeaders: {
    type: Array,
    default: () => []
  }
});

const emit = defineEmits(['openEditModal']);

const handleEditCandidate = (candidateId) => {
  emit('openEditModal', candidateId);
};

const paggingValue = defineModel();
// const sumRecord = candidateData?.length;

// const handleFormat = (value, type) => {
//   switch (type)
// }

</script>

<style scoped>
/* Main content table */
.main-table-body {
  display: block;
  float: left;
  width: calc(100vw - 281px);
  flex: 1 1 0;
  overflow: auto;
}

.main-table-body th {
  text-align: start;
  background-color: #f9fafb;
  border: none;
  outline: none;
}

.main-table-body table {
  border-collapse: collapse;
}

.main-table-body th,
.main-table-body td {
  min-width: 200px;
  border-bottom: 1px solid #ddd;
  height: 48px;
}

.main-table-body th:nth-child(1),
.main-table-body td:nth-child(1) {
  min-width: 50px;
  text-align: center;
}

.main-table-footer {
  display: flex;
  align-items: center;
  padding: 0 20px;
  height: 60px;
  color: #1E2633;
  white-space: nowrap;
}

/* Table full name column */
.table-name-avatar img {
  border-radius: 50%;
  object-fit: cover;
  width: 20px;
  height: 20px;
  margin-right: 5px;
}

.avatar-circle {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 24px;
  height: 24px;
  border-radius: 50%;
  margin-right: 10px;
  color: white;
}

.action-cell {
  min-width: 0 !important;
}

/* Edit remove records */
.data-row {
  position: relative;
}

.data-row .action-cell {
  position: sticky;
  right: 10px;
  z-index: 1;
  min-width: 8px;
}

.data-row .action-buttons {
  display: none;
}

.data-row:hover .action-buttons {
  display: flex;
  gap: 8px
}

.action-buttons .btn-edit,
.action-buttons .btn-delete {
  border: none;
  outline: none;
  background-color: transparent;
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
}

.action-buttons .icon__update:hover {
  background-color: #005a9e;
}

.action-buttons .icon__delete:hover {
  background-color: #d9534f;
}

.paging-selector {
  width: 72px;
  height: 36px;
}
</style>